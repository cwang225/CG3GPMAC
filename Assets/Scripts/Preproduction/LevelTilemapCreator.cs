using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelTilemapCreator : MonoBehaviour
{
    [SerializeField] private GameObject tileSelectionIndicatorPrefab;
    [SerializeField] private GameObject tilePreviewPrefab;
    [SerializeField] private LevelData levelData;

    private Dictionary<Vector2Int, Tile> tiles = new Dictionary<Vector2Int, Tile>();
    
    [HideInInspector] public Vector2Int pos = new Vector2Int();
    [HideInInspector] public int elevation = 0;
    
    Transform marker
    {
        get
        {
            if (_marker == null)
            {
                GameObject instance = Instantiate(tileSelectionIndicatorPrefab) as GameObject;
                _marker = instance.transform;
            }
            return _marker;
        }
    }
    Transform _marker;

    void Awake()
    {
        if (levelData == null)
        {
            Debug.LogError("LevelData is null. Select LevelData object to save to.");
        }
    }

    public void UpdateMarker()
    {
        // Move the tile preview to the current x,z pos and elevation
        marker.position = new Vector3(pos.x * 10.0f, 0.02f + elevation * 5.0f, pos.y * 10.0f);
    }

    public void PlaceTile()
    {
        // Add the tile to our tiles Dictionary
        // Place a tile preview
        if (!tiles.ContainsKey(pos))
        {
            GameObject tile = Instantiate(tilePreviewPrefab,
                new Vector3(pos.x * 10.0f, 0.01f + elevation * 5.0f, pos.y * 10.0f), transform.rotation, transform);
            tiles.Add(pos, tile.GetComponent<Tile>());
            tiles[pos].elevation = elevation;
        }
    }

    public void RemoveTile()
    {
        // Remove the tile from our tiles Dictionary
        // Remove the tile preview
        if (tiles.ContainsKey(pos))
        {
            DestroyImmediate(tiles[pos].gameObject);
            tiles.Remove(pos);
        }
    }

    public void Save()
    {
        // Transfer our tiles Dictionary into a LevelData
        if (levelData == null)
        {
            Debug.LogError("No LevelData assigned!");
            return;
        }

        levelData.tiles.Clear();

        foreach (KeyValuePair<Vector2Int, Tile> tile in tiles)
        {
            TileData td = new TileData
            {
                coord = tile.Key,
                elevation = tile.Value.elevation
            };
            levelData.tiles.Add(td);
        }

        #if UNITY_EDITOR
                UnityEditor.EditorUtility.SetDirty(levelData);
                UnityEditor.AssetDatabase.SaveAssets();
        #endif

        Debug.Log($"Saved {levelData.tiles.Count} tiles into {levelData.name}");
    }

    public void Load()
    {
        // Load a tiles Dictionary from a LevelData and create the tile previews
        if (levelData == null)
        {
            Debug.LogError("No LevelData assigned!");
            return;
        }

        Reset(); // clear scene first

        foreach (TileData td in levelData.tiles)
        {
            GameObject tile = Instantiate(tilePreviewPrefab,
                new Vector3(td.coord.x * 10.0f, 0.01f + td.elevation * 5.0f, td.coord.y * 10.0f),
                transform.rotation, transform);

            Tile tileComp = tile.GetComponent<Tile>();
            tileComp.elevation = td.elevation;

            tiles.Add(td.coord, tileComp);
        }

        Debug.Log($"Loaded {tiles.Count} tiles from {levelData.name}");
    }

    public void Reset()
    {
        foreach (var tile in tiles.Values)
        {
            if (tile != null)
                DestroyImmediate(tile.gameObject);
        }

        tiles.Clear();
        pos = Vector2Int.zero;
        elevation = 0;
        UpdateMarker();
    }
}
