using Unity.VisualScripting;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/15/25
 * Date Last Updated: 10/15/25
 * Summary: An ability effect that does damage to a unit
 */
public class DamageAbilityEffect : AbilityEffect
{

    [SerializeField] private int damage;
    public override int Predict(Tile target)
    {
        // damage formula based on stats of attacker and defender
        return damage;
    }
    
    public override void Apply(Tile target)
    {
        Debug.Log("Applying damage to: " + target + 
                  " | Content: " + (target.content ? target.content.name : "NULL"));
        Health targetHealth = target.content.GetComponent<Health>();
        // target.content.GameObject = ;
        int damage = Predict(target);
        targetHealth.Damage(damage);
    }
}
