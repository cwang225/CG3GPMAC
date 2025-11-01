using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 09/22/25
 * Date Last Updated: 09/22/25
 * Summary: The Alliance of a unit or object (Player, Enemy, Neutral)
 */
public class Alliance : MonoBehaviour
{
    public Alliances type;

    public bool IsMatch(Alliance other, Targets target)
    {
        if (other == null)
        {
            return false;
        }
        if (target == Targets.Ally)
        {
            return type == other.type;
        }
        return type != other.type;
    }
}
