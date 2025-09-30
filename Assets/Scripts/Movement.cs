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

    public IEnumerator Traverse(Tile target)
    {
        // animate the movement by going through the path
        List<Tile> path = new List<Tile>();
        while (target != null)
        {
            path.Insert(0, target);
            target = target.prev;
        }

        for (int i = 1; i < path.Count; i++)
        {
            Tile to = path[i];
            // later can add turning and stuff
            yield return StartCoroutine(Walk(to));
        }
    }

    private IEnumerator Walk(Tile target)
    {
        // tween this later, for now just teleporting
        _unit.Place(target);
        yield return new WaitForSeconds(0.5f);
        _unit.Match();
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
