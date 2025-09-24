using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public void Ramp()
    {
        // First, check if we can do that (need to be between two elevations)
        // Can either be the tile above and below or the one to the left and right
        Directions? dir = null;
            
        if (tiles.ContainsKey(pos + Vector2Int.up) && tiles.ContainsKey(pos + Vector2Int.down))
        {
            float diff = tiles[pos + Vector2Int.up].elevation - tiles[pos + Vector2Int.down].elevation;
            if (diff is 1)
            {
                dir = Directions.North;
            }
            else if (diff is -1)
            {
                dir = Directions.South;
            }
        }

        if (tiles.ContainsKey(pos + Vector2Int.left) && tiles.ContainsKey(pos + Vector2Int.right))
        {
            float diff = tiles[pos + Vector2Int.left].elevation - tiles[pos + Vector2Int.right].elevation;
            if (diff is 1)
            {
                dir = Directions.West;
            }
            else if (diff is -1)
            {
                dir = Directions.East;
            }
        }

        if (dir == null) return;
        
        // Remove a tile if there is one here already
        RemoveTile();
        
        // Place the ramp
        float ramp_elevation = tiles[pos + ((Directions)dir).ToVector2Int()].elevation - 0.5f;
        GameObject tile = Instantiate(tilePreviewPrefab,
            new Vector3(pos.x * 10.0f, 0.01f + ramp_elevation * 5.0f, pos.y * 10.0f), transform.rotation, transform);
        Ramp ramp = tile.AddComponent<Ramp>();
        ramp.rampDirection = (Directions)dir;
        ramp.Match();
        
        tiles.Add(pos, tile.GetComponent<Tile>());
        tiles[pos].elevation = ramp_elevation;
        
        Debug.Log("Made ramp with direction " + (Directions)dir);
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
            Ramp ramp = tile.Value.GetComponent<Ramp>();
            TileData td = new TileData
            {
                coord = tile.Key,
                elevation = tile.Value.elevation,
                isRamp = ramp != null,
                rampDirection = ramp ? ramp.rampDirection : Directions.North
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
