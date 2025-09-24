using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ramp : MonoBehaviour
{
    public Directions rampDirection;

    public void Match()
    {
        // Change the rotation to rotate ramp in the right direction
        switch (rampDirection)
        {
            case Directions.North:
                transform.localEulerAngles = new Vector3(-30, 0, 0);
                break;
            case Directions.East:
                transform.localEulerAngles = new Vector3(0, 0, 30);
                break;
            case Directions.South:
                transform.localEulerAngles = new Vector3(30, 0, 0);
                break;
            case Directions.West:
                transform.localEulerAngles = new Vector3(0, 0, -30);
                break;
            default:
                Debug.LogError("Invalid direction: " + rampDirection);
                break;
        }
    }
}
