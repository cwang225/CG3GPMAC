using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

// This script is used for preproduction. It can be used to test sigils.
[CustomEditor(typeof(LevelSigilEditor))]
public class SigilEditor : Editor
{
    public LevelSigilEditor current
    {
        get
        {
            return (LevelSigilEditor)target;
        }
    }
    // The tile to spawn new sigils on or delete sigils on.
    public Tile tile;
    // An override for the inspector GUI that allows buttons for testing.
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
