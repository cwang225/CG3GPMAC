using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileData {
    public Vector2Int coord;
    public int elevation;
}

[CreateAssetMenu(menuName = "Tactics/Level Data", fileName = "NewLevelData")]
public class LevelData : ScriptableObject {
    public List<TileData> tiles = new List<TileData>();
}