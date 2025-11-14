using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
/**
 * Author: Megan Lincicum
 * Date Created: 09/22/25
 * Date Last Updated: 11/14/25
 * Summary: Movement component for units, facilitates pathfinding based on range and animates to new position.
 */
public class Movement : MonoBehaviour
{
    public int range;
    private Unit _unit;
    private Alliances _alliance;
    private List<Tile> currentPath;
    private Tween tween;

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
        currentPath = new List<Tile>();
        while (target != null)
        {
            currentPath.Insert(0, target);
            target = target.prev;
        }

        //for (int i = 1; i < path.Count; i++)
        //{
        //    Tile from = path[i - 1];
        //    Tile to = path[i];
        //    Directions dir = to.GetDirection(from);
        //    if (_unit.dir != dir)
        //        yield return StartCoroutine(Turn(dir));
        //    yield return StartCoroutine(Walk(to));
        //}

        yield return StartCoroutine(TweenPath(currentPath));
    }

    private IEnumerator TweenPath(List<Tile> path)
    {
        Vector3[] pathNodes = new Vector3[path.Count];
        for (int i = 0; i < path.Count; i++)
        {
            pathNodes[i] = path[i].Center + new Vector3(0, 2.5f, 0);
        }

        tween = transform.DOPath(pathNodes, 0.25f * path.Count).OnWaypointChange(AnimateWaypoint);
        yield return tween.WaitForCompletion();
    }

    private void AnimateWaypoint(int waypointIndex)
    {
        // calculate the direction of the next tile
        Tile target = currentPath[waypointIndex];
        Directions dir = target.GetDirection(_unit.tile);
        // turn if we need to
        if (_unit.dir != dir)
        {
            tween.Pause();
            StartCoroutine(Turn(dir));
        }
        // move to new tile in logic
        _unit.Place(target);
        
    }

    private IEnumerator Walk(Tile target)
    {
        // tween this later, for now just teleporting
        _unit.Place(target);
        yield return StartCoroutine(TweenMovement(target));
    }

    private IEnumerator TweenMovement(Tile target)
    {
        Tween tween = transform.DOMove(target.Center + new Vector3(0, 2.5f, 0), 0.25f);
        yield return tween.WaitForCompletion();
    }

    private IEnumerator Turn(Directions dir)
    {
        _unit.dir = dir;
        yield return StartCoroutine(TweenRotation(dir));
    }

    private IEnumerator TweenRotation(Directions dir)
    {
        Tween tween = transform.DORotate(dir.ToEuler(), 0.15f);
        yield return tween.WaitForCompletion();
        tween.TogglePause();
    }
}
