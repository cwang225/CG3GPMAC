using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/14/25
 * Summary: An ability area that has a radius of effect
 */
public class RangeAbilityArea : AbilityArea
{
    public int horizontal; // x, z
    public int vertical; // elevation
    private Tile _target;
    
    public override List<Tile> GetTilesInArea (TileManager tileManager, Tile target)
    {
        _target = target;
        return tileManager.Search(target, RangeRestriction);
    }
    bool RangeRestriction (Tile from, Tile to)
    {
        return (from.distance + 1) <= horizontal && Mathf.Abs(to.elevation - _target.elevation) <= vertical;
    }
}