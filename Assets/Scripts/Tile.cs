using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    private static readonly int BaseColor = Shader.PropertyToID("_BaseColor");

    // Tile Data
    [HideInInspector] public Vector2Int coord;
    public Vector3 Center => new(coord.x * 10.0f, elevation * 5.0f, coord.y * 10.0f);
    [HideInInspector] public int elevation;
    [HideInInspector] public GameObject content;
    
    // For pathfinding
    [HideInInspector] public Tile prev;
    [HideInInspector] public int distance;
    
    // For tile highlighting/coloring
    [SerializeField] private Color defaultColor;
    [SerializeField] private Color canMoveHereColor;
    [SerializeField] private Color inPathColor;
    
    private MaterialPropertyBlock _block;
    private Renderer _renderer;
    private Color _color;

    private void Awake()
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

    public void ShowMoveable(bool toggle)
    {
        _color = toggle ? canMoveHereColor : defaultColor;
        SetColor(_color);
    }

    public void ShowPath(bool toggle)
    {
        _color = toggle ? inPathColor : canMoveHereColor;
        SetColor(_color);
    }

    private void SetColor(Color color)
    {
        _renderer.GetPropertyBlock(_block);
        _block.SetColor(BaseColor, color);
        _renderer.SetPropertyBlock(_block);
    }
}
