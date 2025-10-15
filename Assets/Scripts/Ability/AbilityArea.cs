using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/14/25
 * Summary: Base class for the area of effect of an ability- ie a single target vs blast radius
 */
public abstract class AbilityArea : MonoBehaviour
{
    public abstract List<Tile> GetTilesInArea (TileManager tileManager, Tile target);
}
