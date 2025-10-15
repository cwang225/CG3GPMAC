using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 09/22/25
 * Date Last Updated: 09/22/25
 * Summary: Rotates a ramp correctly based on its direction.
 */
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
