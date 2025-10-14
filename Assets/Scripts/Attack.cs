using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.Assertions;

public class Attack : MonoBehaviour
{
    // public Unit hoveredUnit;
    public Unit attackTarget;
    public Dictionary<AttackType, int> attackRange = new Dictionary<AttackType, int>();
    public Dictionary<AttackType,int> attackDamages = new Dictionary<AttackType,int>(); // for a sigil, this is damage per turn
    // we have attacks which can be of different kinds
    // all of these in one class is probably okay
    public enum AttackType
    {
        Melee,
        Spell,
        Sigil
    }
    public List<AttackType> availableAttacks;
    // Start is called before the first frame update
    void Start()
    {
        attackRange.Add(AttackType.Melee, 5);
        attackDamages.Add(AttackType.Melee, 5);
        availableAttacks.Add(AttackType.Melee);
    }

    public void AttackEnemyMelee()
    {
        Assert.IsTrue(availableAttacks.Contains(AttackType.Melee));
        var unitComp = gameObject.GetComponent<Unit>();
        Debug.Log(unitComp);
        Debug.Log(attackTarget);
        int xDist = attackTarget.tile.coord.x - unitComp.tile.coord.x;
        int yDist = attackTarget.tile.coord.y - unitComp.tile.coord.y;
        // for now assert, but later display an error
        Debug.Log(attackRange);
        Assert.IsTrue(xDist + yDist <= attackRange[AttackType.Melee]);
        // do some animation probably later
        Health targetHealth = attackTarget.GetComponent<Health>();
        targetHealth.Damage(attackDamages[AttackType.Melee]);
    }
    void OnSelectTarget() {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            var obj = hit.transform.gameObject;
            Alliance objAlliance = (Alliance)obj.GetComponent("Alliance");
            if (objAlliance.type == Alliances.Enemy)
            {
                var unitComp = obj.GetComponent<Unit>();
                Assert.IsTrue(unitComp != null);
                attackTarget = unitComp;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        
    }
}
