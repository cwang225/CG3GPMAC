using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // The tile data for the current level
    [SerializeField] private LevelData levelData;
    
    // The prefab for our tile visual
    [SerializeField] GameObject tilePrefab;
    private const int TileSize = 10;
    
    // The actual variables we will use for game logic, created from levelData
    private Dictionary<Vector2Int, Tile> tiles = new Dictionary<Vector2Int, Tile>();
    
    // Highlighting tiles
    private Tile _highlightedTile;

    void Awake()
    {
        // Create our tilemap from levelData
        if (levelData == null)
        {
            Debug.LogError("LevelData is null");
            return;
        }

        foreach (TileData tileData in levelData.tiles)
        {
            GameObject tile =  Instantiate(tilePrefab, new Vector3(tileData.coord.x * TileSize, 0.01f + tileData.elevation * 5.0f, tileData.coord.y * TileSize), transform.rotation, transform);
            Tile tileComponent = tile.GetComponent<Tile>();
            tileComponent.elevation =  tileData.elevation;
            tiles.Add(tileData.coord, tileComponent);
        }
    }

    void Update()
    {
        // Check to see if the mouse is hovering over a tile to highlight it
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector2Int tilePos = WorldToTile(hit.point);

            if (_highlightedTile)
            {
                _highlightedTile.Highlight(false);
            }
            _highlightedTile = tiles.TryGetValue(tilePos, out Tile tile) ? tile : null;
            if (_highlightedTile)
            {
                _highlightedTile.Highlight(true);
            }
        }

    }
    
    // Turn on or off visuals for tiles
    private void ToggleVisuals(bool toggle)
    {
        foreach (Tile tile in tiles.Values)
        {
            tile.GetComponent<Renderer>().enabled = toggle;
        }
    }
    
    // For coordinates
    private Vector2Int WorldToTile(Vector3 worldPos)
    {
        int tileX = Mathf.FloorToInt((worldPos.x + TileSize / 2f) / TileSize);
        int tileZ = Mathf.FloorToInt((worldPos.z + TileSize / 2f) / TileSize);
        return new Vector2Int(tileX, tileZ);
    }

}
