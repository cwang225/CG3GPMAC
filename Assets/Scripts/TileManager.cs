using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    // The tile data for the current level
    //[SerializeField] private LevelData levelData;
    
    // The prefab for our tile visual
    [SerializeField] GameObject tilePrefab;
    private const int TileSize = 10;
    
    // The actual variables we will use for game logic, created from levelData
    private Dictionary<Vector2Int, Tile> tiles = new Dictionary<Vector2Int, Tile>();
    
    // Highlighting tiles
    private Tile highlightedTile;

    void Awake()
    {
        // Create our tilemap from levelData
        CreateGrid(20, 15);
    }

    void Update()
    {
        // Check to see if the mouse is hovering over a tile to highlight it
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Vector2Int tilePos = WorldToTile(hit.point);

            if (highlightedTile)
            {
                highlightedTile.Highlight(false);
            }
            highlightedTile = tiles.TryGetValue(tilePos, out Tile tile) ? tile : null;
            if (highlightedTile)
            {
                highlightedTile.Highlight(true);
            }
        }

    }
    
    // For testing
    private void CreateGrid(int width, int height)
    {
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject tile =  Instantiate(tilePrefab, new Vector3(i*TileSize, 0.01f, j*TileSize), transform.rotation, transform);
                tile.GetComponent<Tile>().elevation = Random.Range(0, 3);
                tiles.Add(new Vector2Int(i, j), tile.GetComponent<Tile>());
            }
        }
    }
    
    // Turn on or off visuals for tiles
    private void ToggleVisuals(bool toggle)
    {
        foreach (Tile tile in tiles.Values)
        {
            tile.GetComponent<SpriteRenderer>().enabled = toggle;
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
