using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 09/22/25
 * Date Last Updated: 09/22/25
 * Summary: Useful functions for working with Directions
 */
public static class DirectionsExtensions
{
    public static Directions GetDirection(this Tile t1, Tile t2)
    {
        if (t1.coord.y < t2.coord.y)
            return Directions.North;
        if (t1.coord.x < t2.coord.x)
            return Directions.East;
        if (t1.coord.y > t2.coord.y)
            return Directions.South;
        return Directions.West;
    }

    public static Vector3 ToEuler(this Directions direction)
    {
        return new Vector3(0, (int)direction * 90, 0);
    }

    public static Vector2Int ToVector2Int(this Directions direction)
    {
        return new Vector2Int(
            direction == Directions.East ? 1 : direction == Directions.West ? -1 : 0,
            direction == Directions.North ? 1 : direction == Directions.South ? -1 : 0
            );
    }
}
