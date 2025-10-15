using UnityEngine;
using System.Collections.Generic;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/14/25
 * Summary: An abstract class to implement the range of abilities
 */
public abstract class AbilityRange : MonoBehaviour 
{
    public int horizontal = 1; // horizontal as in x, z
    public int vertical = int.MaxValue; // vertical as in elevation
    protected Unit unit { get { return GetComponentInParent<Unit>(); }}

    public abstract List<Tile> GetTilesInRange (TileManager tileManager);
}
