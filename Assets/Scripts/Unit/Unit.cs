using System;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 09/22/25
 * Date Last Updated: 10/15/25
 * Summary: Unit class which holds data for where it is and allows it to be animated across tiles
 */
public class Unit : MonoBehaviour
{
    // What tile the unit is on and which direction it's facing
    public Tile tile { get;  set; }
    public Directions dir;
    public Selectable selection;

    public Sprite headshot;

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
    }

    // Update visuals for new position/direction
    public void Match()
    {
        transform.position = tile.Center + new Vector3(0,2.5f, 0);
        transform.localEulerAngles = dir.ToEuler();
    }
}
