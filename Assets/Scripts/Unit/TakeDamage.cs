using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public Renderer rend;
    public Color flashColor = Color.red;
    public float flashDuration = 0.1f;
    private Color originalColor;

    private void Start()
    {
        originalColor = rend.material.color;
    }

    public IEnumerator DoFlash()
    {
        rend.material.color = flashColor;
        yield return new WaitForSeconds(flashDuration);
        rend.material.color = originalColor;
    }

    public void Flash()
    {
        StopAllCoroutines();
        StartCoroutine(DoFlash());
    }

}
