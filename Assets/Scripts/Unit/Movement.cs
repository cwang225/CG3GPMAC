using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 09/22/25
 * Date Last Updated: 10/15/25
 * Summary: Movement component for units, facilitates pathfinding based on range and animates to new position.
 */
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

    /*
     * Pathfinding
     */
    public List<Tile> GetTilesInRange(TileManager tileManager)
    {
        List<Tile> retValue = tileManager.Search(_unit.tile, MovementRestrictions);
        Filter(retValue);
        return retValue;
    }
    
    private bool MovementRestrictions(Tile from, Tile to)
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
    
    /*
     * Movement animation
     */
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
            Tile from = path[i - 1];
            Tile to = path[i];
            Directions dir = to.GetDirection(from);
            if (_unit.dir != dir)
                yield return StartCoroutine(Turn(dir));
            yield return StartCoroutine(Walk(to));
        }
    }

    private IEnumerator Walk(Tile target)
    {
        // tween this later, for now just teleporting
        _unit.Place(target);
        yield return new WaitForSeconds(0.25f);
        _unit.Match();
    }

    private IEnumerator Turn(Directions dir)
    {
        _unit.dir = dir;
        _unit.Match();
        yield return new WaitForSeconds(0.25f);
    }
}
