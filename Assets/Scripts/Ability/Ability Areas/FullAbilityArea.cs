using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/14/25
 * Summary: An ability area that is just the range of the ability (so relies on unit casting it and cant be targeted)
 */
public class FullAbilityArea : AbilityArea
{
    public override List<Tile> GetTilesInArea (TileManager tileManager, Tile target)
    {
        AbilityRange ar = GetComponent<AbilityRange>();
        return ar.GetTilesInRange(tileManager);
    }
}