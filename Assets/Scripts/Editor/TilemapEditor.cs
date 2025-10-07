using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
/**
 * Author: Megan Lincicum
 * Date Created: 09/15/25
 * Date Last Updated: 10/06/25
 * Summary: The Editor GUI that interfaces with LevelTilemapCreator, allowing easy creation of LevelData during production.
 */
[CustomEditor(typeof(LevelTilemapCreator))]
public class TilemapEditor : Editor
{
    public LevelTilemapCreator current
    {
        get
        {
            return (LevelTilemapCreator) target;
        }
    }
    
    public override void OnInspectorGUI ()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Save"))
            current.Save();
        if (GUILayout.Button("Load"))
            current.Load();
        
        if (GUILayout.Button("Place Tile"))
            current.PlaceTile();
        if (GUILayout.Button("Remove Tile"))
            current.RemoveTile();
        
        GUILayout.Label("Elevation: ");
        current.elevation = (int)GUI.HorizontalSlider (new Rect (100, 185, 100, 30), current.elevation, 0, 2);
        GUILayout.Label("X: " + current.pos.x);
        GUILayout.Label("Y: " + current.pos.y);
        
        if (GUILayout.Button("Add/Make Ramp"))
            current.Ramp();
        
        if (GUILayout.Button("Place Unit"))
            current.PlaceUnit();
        if (GUILayout.Button("Remove Unit"))
            current.RemoveUnit();
        
        if (GUILayout.Button("Reset"))
            current.Reset();

        if (GUI.changed)
            current.UpdateMarker();
        
        Event e = Event.current;
        switch (e.type)
        {
            case EventType.KeyDown:
            {
                switch (Event.current.keyCode)
                {
                    case KeyCode.LeftArrow:
                        if (current.pos.x > 0)
                            current.pos = current.pos - new Vector2Int(1, 0);
                        break;
                    case KeyCode.RightArrow:
                        current.pos = current.pos + new Vector2Int(1, 0);
                        break;
                    case KeyCode.UpArrow:
                        current.pos = current.pos + new Vector2Int(0, 1);
                        break;
                    case KeyCode.DownArrow:
                        if (current.pos.y > 0)
                            current.pos = current.pos - new Vector2Int(0, 1);
                        break;
                }
                current.UpdateMarker();
                break;
            }
        }
    }

}
