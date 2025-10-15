using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/14/25
 * Summary: Targets ally units with less than max health
 */
public class HealableAbilityEffectTarget : AbilityEffectTarget
{
    public override bool IsTarget (Tile tile)
    {
        if (tile == null || tile.content == null)
            return false;
        Alliance alliance = tile.content.GetComponent<Alliance>();
        if (alliance == null || alliance != GetComponentInParent<Alliance>())
            return false;
        Health health = tile.content.GetComponent<Health>();
        return health != null && health.currentHealth < health.maxHealth;
    }

}