using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileData {
    public Vector2Int coord;
    public float elevation;
    public bool isRamp;
    public Directions rampDirection;
}

[CreateAssetMenu(menuName = "Tactics/Level Data", fileName = "NewLevelData")]
public class LevelData : ScriptableObject {
    public List<TileData> tiles = new List<TileData>();
}