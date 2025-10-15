
/**
 * Author: Megan Lincicum
 * Date Created: 10/15/25
 * Date Last Updated: 10/15/25
 * Summary: An ability effect that does damage to a unit
 */
public class DamageAbilityEffect : AbilityEffect
{
    public override int Predict(Tile target)
    {
        // damage formula based on stats of attacker and defender
        return 1;
    }
    
    public override void Apply(Tile target)
    {
        Health targetHealth = target.GetComponent<Health>();
        int damage = Predict(target);
        targetHealth.Damage(damage);
    }
}
