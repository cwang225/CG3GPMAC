
using UnityEngine;

/**
 * Author: Megan Lincicum
 * Date Created: 10/15/25
 * Date Last Updated: 10/15/25
 * Summary: An ability effect that does healsa unit
 */
public class HealAbilityEffect : AbilityEffect
{
    [SerializeField] private int healAmount;

    public override int Predict(Tile target)
    {
        // health formula?
        return healAmount;
    }
    
    public override void Apply(Tile target)
    {
        Health targetHealth = target.GetComponent<Health>();
        int heal = Predict(target);
        targetHealth.Heal(heal);
    }
}