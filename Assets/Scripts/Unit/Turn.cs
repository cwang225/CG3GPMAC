using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/07/25
 * Date Last Updated: 10/07/25
 * Summary: Tracks the turn of a Unit and locks movement once an action is taken
 */
public class Turn : MonoBehaviour
{
    public bool hasMoved;
    public bool hasActed;

    public bool CanMove => !(hasMoved || hasActed);
    public bool CanAct => !hasActed; // later we may want to expand this for status effects?
    
    public void ResetTurn()
    {
        hasMoved = false;
        hasActed = false;
    }
}
