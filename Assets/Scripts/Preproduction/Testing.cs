using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    [SerializeField] private TileManager _tileManager;
    [SerializeField] private Unit _unit;

    void Start()
    {
        _unit.tile = _tileManager.GetTile(new Vector2Int(0, 0));
        Movement movement = _unit.GetComponent<Movement>();
        List<Tile> tilesInRange = movement.GetTilesInRange(_tileManager);
        _tileManager.ShowTilesAsMoveable(tilesInRange);
    }
}
