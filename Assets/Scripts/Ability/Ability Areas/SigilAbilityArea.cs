using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/15/25
 * Date Last Updated: 10/15/25
 * Summary: Ability area for a sigil, its a circle (square) so diagonal is involved in radius
 */
public class SigilAbilityArea : AbilityArea
{
    public int radius;
    private Tile _target;

    public override List<Tile> GetTilesInArea(TileManager tileManager, Tile target)
    {
        _target = target;
        return tileManager.Search(target, RangeRestriction);
    }
    bool RangeRestriction(Tile from, Tile to)
    {
        return Mathf.Abs(to.coord.x - _target.coord.x) <= radius && Mathf.Abs(to.coord.y - _target.coord.y) <= radius;
    }
}
