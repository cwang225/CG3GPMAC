using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    // What tile the unit is on and which direction it's facing
    public Tile tile { get;  set; }
    public Directions dir;
    public Selectable selection;

    private void Awake()
    {
        selection = GetComponent<Selectable>();
    }

    public void Place(Tile target)
    {
        // Remove this unit from the previous tile
        if (tile != null && tile.content == gameObject) 
        {
            tile.content = null;
        }
        
        // Move to new tile and add reference to this unit
        tile = target;

        if (target != null)
        {
            target.content = gameObject;
        }

        Match();
    }

    // Update visuals for new position/direction
    public void Match()
    {
        transform.position = tile.Center + new Vector3(0,2.5f, 0);
        transform.localEulerAngles = dir.ToEuler();
    }
}
