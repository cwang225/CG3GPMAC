using UnityEngine;
using UnityEngine.Events;
/**
 * Author: Megan Lincicum
 * Date Created: 09/22/25
 * Date Last Updated: 10/31/25
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
            currentHealth = 0;
            OnKO.Invoke();

            // LATER: this shouldn't be done here
            // make the unit look fallen over
            transform.Rotate(90, 0, 0);
            transform.position = transform.position - new Vector3(0, 2.5f, 0);
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
