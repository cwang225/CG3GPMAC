using System;
using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 09/15/25
 * Date Last Updated: 10/15/25
 * Summary: Holds the grid of tiles in a battle, manages highlighting and pathfinding.
 */
public class TileManager : MonoBehaviour
{
    // The prefab for our tile visual
    [Header("Tile Overlay")]
    [SerializeField] GameObject tileOverlayPrefab;
    [SerializeField] Transform tileSelectIndicator;

    [Header("Highlight Colors")]
    [SerializeField] Color moveColor;
    [SerializeField] Color pathColor;
    [SerializeField] Color rangeColor;

    private const int TileSize = 10;
    
    // The actual Tiles used during gameplay
    private Dictionary<Vector2Int, Tile> tiles = new Dictionary<Vector2Int, Tile>();
    
    // Highlighting tiles
    public Tile HoveredTile { get; protected set; }
    private Tile _highlightedTile;
    private Tile _selectedTile;

    void Update()
    {
        CheckHoveredTile();
    }

    private void CheckHoveredTile()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector2Int tilePos = WorldToTile(hit.point);

            HoveredTile = tiles.TryGetValue(tilePos, out Tile tile) ? tile : null;

            HighlightTile();
        }
    }
    
    public void Load(LevelData levelData)
    {
        // Create our tilemap from levelData
        if (levelData == null)
        {
            Debug.LogError("LevelData is null");
            return;
        }

        foreach (TileData tileData in levelData.tiles)
        {
            GameObject tile =  Instantiate(tileOverlayPrefab, TileToWorld(tileData.coord, tileData.elevation), transform.rotation, transform);
            Tile tileComponent = tile.GetComponent<Tile>();
            tileComponent.coord = tileData.coord;
            tileComponent.elevation =  tileData.elevation;

            // Check for ramp
            if (tileData.isRamp)
            {
                Ramp ramp = tile.AddComponent<Ramp>();
                ramp.rampDirection = tileData.rampDirection;
                ramp.Match();
            }
            
            tiles.Add(tileData.coord, tileComponent);
        }
    }
    
    private void HighlightTile()
    {
        if (_highlightedTile)
        {
            _highlightedTile.Highlight(false);
        }
        _highlightedTile = HoveredTile;
        if (_highlightedTile)
        {
            _highlightedTile.Highlight(true);
        }
    }

    public void SelectTile(Tile tile)
    {
        if (_selectedTile == null) tileSelectIndicator.gameObject.SetActive(true);
        tileSelectIndicator.position = TileToWorld(tile.coord, tile.elevation);
    }

    public void DeselectTile()
    {
        _selectedTile = null;
        tileSelectIndicator.gameObject.SetActive(false);
    }
    
    // For coordinates
    public static Vector2Int WorldToTile(Vector3 worldPos)
    {
        int tileX = Mathf.FloorToInt((worldPos.x + TileSize / 2f) / TileSize);
        int tileZ = Mathf.FloorToInt((worldPos.z + TileSize / 2f) / TileSize);
        return new Vector2Int(tileX, tileZ);
    }

    public static Vector3 TileToWorld(Vector2Int tilePos, float elevation)
    {
        float tileX = tilePos.x * TileSize;
        float tileZ = tilePos.y * TileSize;
        float tileY = 0.01f + elevation * 5.0f;
        return new Vector3(tileX, tileY, tileZ);
    }

    // Pathfinding - returns all tiles that can be moved to based on predicate
    public List<Tile> Search(Tile start, Func<Tile, Tile, bool> predicate)
    {
        List<Tile> retValue = new List<Tile>();
        retValue.Add(start);
        
        ClearSearch();
        Queue<Tile> checkNext = new Queue<Tile>();
        Queue<Tile> checkNow = new Queue<Tile>();
        
        start.distance = 0;
        checkNow.Enqueue(start);

        while (checkNow.Count > 0)
        {
            Tile tile = checkNow.Dequeue();

            for (int i = 0; i < 4; i++)
            {
                Tile next = GetTile(tile.coord + ((Directions)i).ToVector2Int());
                if (next == null || next.distance < tile.distance + 1) continue;

                if (predicate(tile, next))
                {
                    next.distance = tile.distance + 1;
                    next.prev = tile;
                    checkNext.Enqueue(next);
                    retValue.Add(next);
                }
            }

            if (checkNow.Count == 0)
            {
                SwapReference( ref checkNow, ref checkNext);
            }
        }
        
        return retValue;
    }

    void ClearSearch()
    {
        foreach (Tile tile in tiles.Values)
        {
            tile.prev = null;
            tile.distance = int.MaxValue;
        }
    }

    public Tile GetTile(Vector2Int coord)
    {
        return tiles.ContainsKey(coord) ? tiles[coord] : null;
    }

    void SwapReference(ref Queue<Tile> a, ref Queue<Tile> b)
    {
        (a, b) = (b, a);
    }

    public void HighlightTiles(List<Tile> tiles, Color color)
    {
        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].ChangeColor(color);
        }
    }
    public void HighlightTiles(List<Tile> tiles, String key)
    {
        Color color;
        switch (key) {
            case "Move":
                color = moveColor;
                break;
            case "Path":
                color = pathColor;
                break;
            case "Range":
                color = rangeColor;
                break;
            default:
                print("Invalid highlight color key");
                return;
        }
        for (int i = 0; i < tiles.Count; i++)
        {
            tiles[i].ChangeColor(color);
        }
    }


    public void ClearTileDisplay()
    {
        foreach (Tile tile in tiles.Values)
        {
            tile.ResetColor();
        }
    }
}
