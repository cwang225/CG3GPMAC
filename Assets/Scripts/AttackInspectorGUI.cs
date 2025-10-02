using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Attack))]
public class AttackInspectorGUI : Editor
{
    public Attack current {
        get
        {
            return (Attack) target;
        }
    }
    public Unit attackTarget;
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        if (GUILayout.Button("Attack target from unit"))
        {
            current.AttackEnemyMelee();
        }
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
