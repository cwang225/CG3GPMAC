using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class LevelSigilEditor : MonoBehaviour
{
    // Start is called before the first frame update

    public Tile currentTile;
    public Dictionary<Tile,Sigil> sigils;
    public GameObject prefabSigil;

    public void PlaceSigil()
    {
        GameObject gobj = Instantiate(prefabSigil);
        Sigil s = gobj.GetComponent<Sigil>();
        Assert.IsNotNull(s);
        s.tile = currentTile;
    }
    public void RemoveSigil()
    {
        var sigilToRemove = sigils[currentTile];
        Assert.IsNotNull(sigilToRemove);
        sigils[currentTile] = null;
        Destroy(sigilToRemove);
    }
    public void dealAOEDamageAll()
    {
        foreach (Sigil s in sigils.Values)
        {
            s.dealAOEDamage();
        }
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
