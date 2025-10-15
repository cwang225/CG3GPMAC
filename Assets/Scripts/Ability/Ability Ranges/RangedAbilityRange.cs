using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/14/25
 * Summary: For ranged attacks, can only target tiles at the same or lower elevation
 */
public class RangedAbilityRange : AbilityRange
{
    public override List<Tile> GetTilesInRange (TileManager tileManager)
    {
        return tileManager.Search(unit.tile, RangeRestriction);
    }
    bool RangeRestriction (Tile from, Tile to)
    {
        return (from.distance + 1) <= horizontal && to.elevation <= unit.tile.elevation;
    }
}