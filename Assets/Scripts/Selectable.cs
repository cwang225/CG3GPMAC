using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/01/25
 * Summary: Script to highlight an object when it is selected
 */
public class Selectable : MonoBehaviour
{
    private static readonly int Enabled = Shader.PropertyToID("_Enabled");
    private Renderer _renderer;
    private Material _outlineMat;

    void Awake()
    {
        //_renderer = GetComponent<Renderer>();
        //_outlineMat = _renderer.materials[1];
    }

    public void SetSelected(bool selected)
    {
        //_outlineMat.SetFloat(Enabled, selected ? 1f : 0f);
    }
}
