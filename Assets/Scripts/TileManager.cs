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
    private Dictionary<Vector2Int, GameObject> tiles = new Dictionary<Vector2Int, GameObject>();

    void Awake()
    {
        // Create our tiles dictionary from levelData
        CreateGrid(20, 15);
        // Instantiate all of our tile prefabs in the correct location
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
                tiles.Add(new Vector2Int(i, j), tile);
            }
        }
    }
    
    // Turn on or off visuals for tiles
    private void toggleVisuals(bool toggle)
    {
        foreach (GameObject tile in tiles.Values)
        {
            tile.GetComponent<SpriteRenderer>().enabled = toggle;
        }
    }
}
