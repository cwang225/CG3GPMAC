using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public int range;
    private Unit _unit;
    private Alliances _alliance;

    void Awake()
    {
        _unit = GetComponent<Unit>();
        _alliance = GetComponent<Alliance>().type;
    }

    public List<Tile> GetTilesInRange(TileManager tileManager)
    {
        List<Tile> retValue = tileManager.Search(_unit.tile, ExpandSearch);
        Filter(retValue);
        return retValue;
    }
    
    private bool ExpandSearch(Tile from, Tile to)
    {
        // elevation
        if (to.elevation >= from.elevation + 1) return false;
        //later: jumping down restrictions?
        
        // enemies
        if (to.content != null)
        {
            Alliance otherAlliance = to.content.GetComponent<Alliance>();
            if (otherAlliance != null && otherAlliance.type != _alliance) 
                return false;
        }
        
        return (from.distance + 1) <= range;
    }

    private void Filter(List<Tile> tiles)
    {
        for (int i = tiles.Count - 1; i >= 0; --i)
            if (tiles[i].content != null)
                tiles.RemoveAt(i);
    }
}
