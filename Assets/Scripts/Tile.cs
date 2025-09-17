using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Tile Data
    public int elevation;
    
    // For tile highlight
    private MaterialPropertyBlock _block;
    private Renderer _renderer;
    private Color _color;

    private void Awake()
    {
        _block = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();
        _color = _renderer.material.color;
    }

    public void Highlight(bool toggle)
    {
        if (toggle)
        {
            _renderer.GetPropertyBlock(_block);
            _block.SetColor("_BaseColor", Color.Lerp(_color, Color.white, 0.5f)); // brighter green
            _renderer.SetPropertyBlock(_block);
        }
        else
        {
            _renderer.GetPropertyBlock(_block);
            _block.SetColor("_BaseColor", _color);
            _renderer.SetPropertyBlock(_block);
        }
    }
}
