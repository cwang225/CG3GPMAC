using UnityEngine;
using UnityEngine.Events;
/**
 * Author: Megan Lincicum
 * Date Created: 09/22/25
 * Date Last Updated: 09/22/25
 * Summary: The health of a Unit or other object.
 */
public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public UnityEvent OnDeath;

    void Awake()
    {
        if (OnDeath == null)
        {
            OnDeath = new UnityEvent();
        }
}

    public void Damage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            OnDeath.Invoke();
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth) 
        {
            currentHealth = maxHealth;
        }
    }
}
