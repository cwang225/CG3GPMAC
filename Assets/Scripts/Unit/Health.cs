using System.Collections;
using DG.Tweening.Core.Easing;
using UnityEditor.ShaderGraph;
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
    private Renderer[] rend;
    private Color[] originalColors;
    public Color flashColor = Color.red;
    public float flashDuration = 1f;

    private void Start()
    {
        currentHealth = maxHealth;
        rend = GetComponentsInChildren<Renderer>();
        originalColors = new Color[rend.Length];
        int i = 0;
        foreach (Renderer render in rend)
        {
            originalColors[i] = render.material.color;
            i++;
        }
        
    }

    public void Damage(int amount)
    {   
        Flash();
        Debug.Log("flashed red");
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

    private IEnumerator DoFlash()
    {
        foreach (Renderer render in rend) {
            render.material.color = flashColor;
        }
        yield return new WaitForSeconds(flashDuration);
        int i = 0;
        foreach (Renderer render in rend) {
            render.material.color = originalColors[i];
            i++;
        }
    }

    private void Flash()
    {
        StopAllCoroutines();
        StartCoroutine(DoFlash());
    }

    void Awake()
    {
        if (OnKO == null)
        {
            OnKO = new UnityEvent();
        }
    }

}
