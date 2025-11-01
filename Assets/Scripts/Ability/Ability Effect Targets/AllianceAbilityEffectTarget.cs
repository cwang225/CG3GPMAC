/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/31/25
 * Summary: The default ability effect target that just limits itself to one alliance (ally or foe)
 */
public class AllianceAbilityEffectTarget : AbilityEffectTarget
{
    public Targets target;
    
    public override bool IsTarget (Tile tile)
    {
        if (tile == null || tile.content == null)
            return false;
        Alliance alliance = tile.content.GetComponent<Alliance>();
        if (alliance == null || !alliance.IsMatch(GetComponentInParent<Alliance>(), target))
            return false;
        Health health = tile.content.GetComponent<Health>();
        return health != null && !health.KOd;
    }
}
