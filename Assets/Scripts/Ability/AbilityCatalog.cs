using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/15/25
 * Date Last Updated: 10/15/25
 * Summary: Holds and retrieves the abilities available to a unit
 */
public class AbilityCatalog : MonoBehaviour
{
    public int AbilityCount()
    {
        return transform.childCount;
    }

    public Ability GetAbility(int index)
    {
        return transform.GetChild(index).GetComponent<Ability>();
    }
}
