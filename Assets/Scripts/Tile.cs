using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 09/15/25
 * Date Last Updated: 10/15/25
 * Summary: Data and visualization of a tile in the battle grid
 */
public class Tile : MonoBehaviour
{
    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");

    // Tile Data
    [HideInInspector] public Vector2Int coord;
    public Vector3 Center => new(coord.x * 10.0f, elevation * 5.0f, coord.y * 10.0f);
    public float elevation;
    public GameObject content;
    
    // For pathfinding
    [HideInInspector] public Tile prev;
    [HideInInspector] public int distance;
    
    // For tile highlighting/coloring
    [Header("Unhighlighted Color")]
    [SerializeField] private Color defaultColor;
    
    private MaterialPropertyBlock _block;
    private Renderer _renderer;
    private Color _color;

    void Awake()
    {
        _block = new MaterialPropertyBlock();
        _renderer = GetComponent<Renderer>();

        _color = defaultColor;
        SetColor(_color);
    }
    
    public void Highlight(bool toggle)
    {
        SetColor(toggle ? Color.Lerp(_color, Color.white, 0.5f) : _color);
    }

    public void ResetColor()
    {
        ChangeColor(defaultColor);
    }

    public void ChangeColor(Color color)
    {
        _color = color;
        SetColor(color);
    }

    private void SetColor(Color color)
    {
        _renderer.GetPropertyBlock(_block);
        _block.SetColor(BaseColor, color);
        _renderer.SetPropertyBlock(_block);
    }
}
