using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEngine.Assertions;

public class Sigil : MonoBehaviour
{
    public Tile tile;
    public int range;
    public List<GameObject> entitiesInRange;
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
