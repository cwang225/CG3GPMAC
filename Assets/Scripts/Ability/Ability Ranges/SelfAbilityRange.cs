using System.Collections.Generic;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/14/25
 * Summary: Range for an ability that targets the unit using it
 */
public class SelfAbilityRange : AbilityRange
{
    public override List<Tile> GetTilesInRange (TileManager tileManager)
    {
        List<Tile> retValue = new List<Tile>(1);
        retValue.Add(unit.tile);
        return retValue;
    }
}