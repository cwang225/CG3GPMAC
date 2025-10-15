using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/14/25
 * Summary: An ability area that effects just the targeted unit/tile
 */
public class SingleTargetAbilityArea : AbilityArea
{
    //todo can probably change this to just take in the tile?
    public override List<Tile> GetTilesInArea (TileManager tileManager, Tile target)
    {
        List<Tile> retValue = new List<Tile>();
        retValue.Add(target);
        return retValue;
    }
}
