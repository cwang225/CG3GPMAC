using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 09/15/25
 * Date Last Updated: 10/06/25
 * Summary: A Level Creator for use during production, places tiles and units and saves the data to a LevelData.
 */
public class LevelTilemapCreator : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject tileSelectionIndicatorPrefab;
    [SerializeField] private GameObject tilePreviewPrefab;
    
    [Header("Level to Save/Load")]
    [SerializeField] private LevelData levelData;
    
    [Header("Unit Placement")]
    [SerializeField] private UnitRecipe unitToPlace;

    private Dictionary<Vector2Int, Tile> tiles = new Dictionary<Vector2Int, Tile>();
    private Dictionary<Vector2Int, UnitRecipe> units = new Dictionary<Vector2Int, UnitRecipe>();
    
    [HideInInspector] public Vector2Int pos = new Vector2Int();
    [HideInInspector] public int elevation = 0;
    
    [Header("Controls")]
    
    Transform marker
    {
        get
        {
            if (_marker == null)
            {
                GameObject instance = Instantiate(tileSelectionIndicatorPrefab, transform, true) as GameObject;
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

        Clear();
    }

    public void Clear()
    {
        // destroy all children
        for (int i = this.transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(this.transform.GetChild(i).gameObject);
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
            Tile tileComp = tile.GetComponent<Tile>();
            tileComp.coord = pos;
            tiles.Add(pos, tileComp);
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

    public void PlaceUnit()
    {
        if (unitToPlace != null)
        {
            if (tiles.ContainsKey(pos) && tiles[pos].content == null)
            {
                GameObject instance = UnitFactory.Create(unitToPlace);
                instance.transform.parent = transform;
                Unit unit = instance.GetComponent<Unit>();
                unit.Place(tiles[pos]);
                units.Add(pos, unitToPlace);
            }
        }
    }

    public void RemoveUnit()
    {
        if (tiles.ContainsKey(pos))
        {
            GameObject content = tiles[pos].content;
            if (content != null)
            {
                DestroyImmediate(content);
                units.Remove(pos);
            }
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

        // TILES
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
        
        // UNITS
        levelData.units.Clear();
        
        foreach (KeyValuePair<Vector2Int, UnitRecipe> unit in units)
        {
            UnitData ud = new UnitData
            {
                coord = unit.Key,
                recipe = unit.Value
            };
            levelData.units.Add(ud);
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

        //TILES
        foreach (TileData td in levelData.tiles)
        {
            GameObject tile = Instantiate(tilePreviewPrefab,
                new Vector3(td.coord.x * 10.0f, 0.01f + td.elevation * 5.0f, td.coord.y * 10.0f),
                transform.rotation, transform);

            Tile tileComp = tile.GetComponent<Tile>();
            tileComp.coord = td.coord;
            tileComp.elevation = td.elevation;

            tiles.Add(td.coord, tileComp);
        }
        
        //UNITS
        foreach (UnitData ud in levelData.units)
        {
            GameObject unit = UnitFactory.Create(ud.recipe);
            unit.transform.parent = transform;
            Unit unitComp = unit.GetComponent<Unit>();
            unitComp.Place(tiles[ud.coord]);
            
            units.Add(ud.coord, ud.recipe);
        }

        Debug.Log($"Loaded {tiles.Count} tiles from {levelData.name}");
    }

    public void Reset()
    {
        Clear();

        tiles.Clear();
        units.Clear();
        pos = Vector2Int.zero;
        elevation = 0;
        UpdateMarker();
    }
}
