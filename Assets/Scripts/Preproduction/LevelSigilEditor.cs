using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

// This script is used to test sigils in preproduction along with the SigilEditor script.
public class LevelSigilEditor : MonoBehaviour
{
    // Start is called before the first frame update

    // The tile on which to place or remove sigils.
    public Tile currentTile;
    // The map from tiles in the world to associated sigils.
    public Dictionary<Tile, Sigil> sigils = new Dictionary<Tile, Sigil>();
    // The sigil to use when spawning new sigils.
    public GameObject prefabSigil;

    public void PlaceSigil()
    {
        GameObject gobj = Instantiate(prefabSigil);
        Sigil s = gobj.GetComponent<Sigil>();
        Assert.IsNotNull(s);
        s.tile = currentTile;
        print(s.tile);
        sigils.Add(s.tile, s);
    }
    public void RemoveSigil()
    {
        print(currentTile);
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
