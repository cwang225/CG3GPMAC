using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEngine.Assertions;

// This implements the basic functionality for the sigil,
// in particular snapping to a tile and dealing AoE damage to units in its range.
// Currently it does damage to units without regard to team affiliation.
public class Sigil : MonoBehaviour
{
    // The tile that the sigil is snapping to.
    public Tile tile;
    // The radius of the sphere in which units will be damaged by the sigil.
    public int range;
    // The list of entities inside the sphere of effect.
    public List<GameObject> entitiesInRange;
    // The amount of damage the sigil will do per-invocation of AoE damage,
    public int damage;
    // Start is called before the first frame update
    void Start()
    {

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position, range);
    }

    public void dealAOEDamage()
    {
        // get a list of entities at tiles within a certain distance
        // based on traversibility
        // it would be easier to do a radius maybe
        foreach (GameObject ent in entitiesInRange)
        {
            print("attempting to damage unit");
            var lifecomp = ent.GetComponent<Health>();
            lifecomp.Damage(damage);
            print("unit " + ent + " now at life " + lifecomp);
        }
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = tile.transform.position;
        // TODO: figure out how to make this a cylinder
        Collider[] collidersInRange = Physics.OverlapSphere(gameObject.transform.position, range);
        print("length of colliders in Sigil.Update(): " + collidersInRange.Length);
        print("len of collidersInRange: " + collidersInRange.Length);
        entitiesInRange.Clear();
        foreach (Collider c in collidersInRange)
        {
            // XXX: this is almost certainly where we're not detecting units
            var unitComp = c.gameObject.GetComponent<Unit>();
            print("unitComp: " + unitComp);
            if (unitComp != null)
            {
                print("appending unit to entitiesInRange");
                entitiesInRange.Add(c.gameObject);
            }
        }
    }
}
