using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    // Tile Data
    public int elevation;

    void Start()
    {
        // Set y-height equal to elevation
        transform.position = new Vector3(transform.position.x, elevation * 5 + 0.01f, transform.position.z);
    }
}
