using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(LevelSigilEditor))]
public class SigilEditor : Editor
{
    public LevelSigilEditor current {
        get
        {
            return (LevelSigilEditor) target;
        }
    }
    public Tile tile;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Place Sigil"))
            current.PlaceSigil();
        if (GUILayout.Button("Remove Sigil"))
            current.RemoveSigil();
        if (GUILayout.Button("Deal AOE Damage"))
            current.dealAOEDamageAll();
        if (GUILayout.Button("Change Tile"))
            current.currentTile = tile;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
