using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private TileManager tileManager;
    [SerializeField] private Unit unit;
    private Movement _movement;
    private List<Tile> _tilesInRange;
    private List<Tile> _currentPath;
    
    void Start()
    {
        unit.tile = tileManager.GetTile(new Vector2Int(0, 0));
        _movement = unit.GetComponent<Movement>();
        GetTilesInRange();
    }

    void Update()
    {
        // show the path
        Tile highlightedTile = tileManager.HoveredTile;
        if (_tilesInRange.Contains(highlightedTile))
        {
            if (_currentPath != null) ClearPathDisplay(_currentPath);
            _currentPath = DisplayPath(highlightedTile);
            
            if (Input.GetMouseButtonDown(0))
            {
                unit.Place(highlightedTile);
                GetTilesInRange();
            }
        }
    }

    void GetTilesInRange()
    {
        _tilesInRange = _movement.GetTilesInRange(tileManager);
        tileManager.ClearTileDisplay();
        tileManager.ShowTilesAsMoveable(_tilesInRange);
    }

    void ClearPathDisplay(List<Tile> tiles)
    {
        foreach (Tile tile in tiles)
        {
            tile.ShowPath(false);
        }
    }

    List<Tile> DisplayPath(Tile target)
    {
        List<Tile> path = new List<Tile>();
        while (target != null)
        {
            path.Add(target);
            target.ShowPath(true);
            target = target.prev;
        }

        return path;
    }
}
