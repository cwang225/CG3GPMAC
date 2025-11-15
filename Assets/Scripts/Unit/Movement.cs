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

    private Transform visualRoot; // child for tilting

    [Header("Movement Settings")]
    public float tileMoveDuration = 0.25f; // per tile
    public float pathEaseDurationMultiplier = 1f; // duration = tileMoveDuration * (tiles-1)
    public float tiltAngle = -10f;
    public float tiltEaseDuration = 0.1f; // duration for tilt in/out
    public Ease moveEase = Ease.InOutSine;
    public float turnDuration = 0.15f;

    void Awake()
    {
        _unit = GetComponent<Unit>();
        _alliance = GetComponent<Alliance>().type;

        visualRoot = transform.GetChild(0);
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
        // Build tile list (same as before)
        currentPath = new List<Tile>();
        while (target != null)
        {
            currentPath.Insert(0, target);
            target = target.prev;
        }

        yield return AnimateSegments(currentPath);
    }

    private IEnumerator AnimateSegments(List<Tile> path)
    {
        List<List<Tile>> segments = SplitIntoStraightSegments(path);

        foreach (var seg in segments)
        {
            Tile start = seg[0];
            Tile end = seg[seg.Count - 1];

            // Determine direction for this segment
            Directions segDir = end.GetDirection(start);

            // Rotate parent toward segment direction if needed
            if (_unit.dir != segDir)
            {
                yield return StartCoroutine(RotateTo(segDir));
                _unit.dir = segDir;
            }

            // Move along the segment
            Vector3[] positions = new Vector3[seg.Count];
            for (int i = 0; i < seg.Count; i++)
                positions[i] = seg[i].Center + new Vector3(0, 2.5f, 0);

            float duration = tileMoveDuration * (seg.Count - 1) * pathEaseDurationMultiplier;

            // Create movement tween
            Tween moveTween = transform.DOPath(positions, duration, PathType.Linear)
                .SetEase(moveEase);

            // Create tilt sequence that matches movement duration
            Sequence tiltSeq = DOTween.Sequence();
            tiltSeq.Append(visualRoot.DOLocalRotate(new Vector3(tiltAngle, 0, 0), tiltEaseDuration).SetEase(Ease.OutSine)); // ease in
            tiltSeq.AppendInterval(duration - 2 * tiltEaseDuration); // stay tilted
            tiltSeq.Append(visualRoot.DOLocalRotate(Vector3.zero, tiltEaseDuration).SetEase(Ease.InSine)); // ease out

            // Start both tweens simultaneously
            moveTween.Play();
            tiltSeq.Play();

            yield return moveTween.WaitForCompletion();

            // End of segment: place unit, ensure tilt reset
            _unit.Place(end);
            visualRoot.localRotation = Quaternion.identity;
        }
    }

    // ----------------------
    // Rotation helper
    // ----------------------
    private IEnumerator RotateTo(Directions dir)
    {
        Tween rotTween = transform.DORotate(dir.ToEuler(), turnDuration)
            .SetEase(Ease.OutSine);
        yield return rotTween.WaitForCompletion();
    }

    // ----------------------
    // Split path into straight segments
    // ----------------------
    private List<List<Tile>> SplitIntoStraightSegments(List<Tile> path)
    {
        List<List<Tile>> result = new List<List<Tile>>();
        List<Tile> current = new List<Tile>();
        current.Add(path[0]);

        Directions? lastDir = null;

        for (int i = 1; i < path.Count; i++)
        {
            Tile prev = path[i - 1];
            Tile next = path[i];
            Directions dir = next.GetDirection(prev);

            if (lastDir == null)
            {
                lastDir = dir;
                current.Add(next);
            }
            else if (dir == lastDir)
            {
                current.Add(next);
            }
            else
            {
                result.Add(new List<Tile>(current));
                current.Clear();
                current.Add(prev);
                current.Add(next);
                lastDir = dir;
            }
        }

        result.Add(current);
        return result;
    }



}
