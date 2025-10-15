using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 09/15/25
 * Date Last Updated: 09/15/25
 * Summary: The list of tiles and units needed to load a level.
 */

// Data object for one tile
[System.Serializable]
public class TileData {
    public Vector2Int coord;
    public float elevation;
    public bool isRamp;
    public Directions rampDirection;
}

// Data object for one unit
[System.Serializable]
public class UnitData
{
    public Vector2Int coord;
    public UnitRecipe recipe;
}

// Scriptable object for LevelData
[CreateAssetMenu(menuName = "Tactics/Level Data", fileName = "NewLevelData")]
public class LevelData : ScriptableObject {
    public List<TileData> tiles = new List<TileData>();
    public List<UnitData> units = new List<UnitData>();
}