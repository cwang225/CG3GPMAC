using UnityEngine;
using UnityEngine.Events;
/**
 * Author: Megan Lincicum
 * Date Created: 09/22/25
 * Date Last Updated: 10/30/25
 * Summary: The health of a Unit or other object.
 */
public class Health : MonoBehaviour
{
    public int maxHealth;
    public int currentHealth;
    public bool KOd => currentHealth == 0;
    public UnityEvent OnKO;

    void Awake()
    {
        if (OnKO == null)
        {
            OnKO = new UnityEvent();
        }
    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void Damage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            OnKO.Invoke();
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
