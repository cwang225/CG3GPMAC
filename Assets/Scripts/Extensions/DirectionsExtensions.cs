using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
