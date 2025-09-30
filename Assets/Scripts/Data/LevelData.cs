using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileData {
    public Vector2Int coord;
    public float elevation;
    public bool isRamp;
    public Directions rampDirection;
}

[System.Serializable]
public class UnitData
{
    public Vector2Int coord;
    public UnitRecipe recipe;
}

[CreateAssetMenu(menuName = "Tactics/Level Data", fileName = "NewLevelData")]
public class LevelData : ScriptableObject {
    public List<TileData> tiles = new List<TileData>();
    public List<UnitData> units = new List<UnitData>();
}