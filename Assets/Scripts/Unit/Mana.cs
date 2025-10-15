using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 09/22/25
 * Date Last Updated: 10/15/25
 * Summary: The mana of a Unit or other object.
 */
public class Mana : MonoBehaviour
{
    public int maxMana;
    public int currentMana;

    private void Start()
    {
        currentMana = maxMana;
    }

    public void Drain(int amount)
    {
        currentMana -= amount;
        if (currentMana < 0)
            currentMana = 0;
    }

    public void Restore(int amount)
    {
        currentMana += amount;
        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
    }
}
