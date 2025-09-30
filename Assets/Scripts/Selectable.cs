using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selectable : MonoBehaviour
{
    private static readonly int Enabled = Shader.PropertyToID("_Enabled");
    private Renderer _renderer;
    private Material _outlineMat;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
        _outlineMat = _renderer.materials[1];
    }

    public void SetSelected(bool selected)
    {
        _outlineMat.SetFloat(Enabled, selected ? 1f : 0f);
    }
}
