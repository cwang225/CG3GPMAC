using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 09/22/25
 * Date Last Updated: 09/22/25
 * Summary: The mana of a Unit or other object.
 */
public class Mana : MonoBehaviour
{
    public int maxMana;
    private int currentMana;

    public void Add(int amount)
    {
        currentMana += amount;
        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
    }
}
