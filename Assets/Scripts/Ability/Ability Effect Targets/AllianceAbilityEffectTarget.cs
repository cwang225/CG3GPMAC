/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/30/25
 * Summary: The default ability effect target that just limits itself to one alliance (ally or foe)
 */
public class AllianceAbilityEffectTarget : AbilityEffectTarget
{
    public enum Target
    {
        Ally,
        Foe
    }

    public Target target;
    
    public override bool IsTarget (Tile tile)
    {
        if (tile == null || tile.content == null)
            return false;
        Alliance alliance = tile.content.GetComponent<Alliance>();
        if (alliance == null || !IsTargetAlliance(alliance))
            return false;
        Health health = tile.content.GetComponent<Health>();
        return health != null && !health.KOd;
    }

    private bool IsTargetAlliance(Alliance alliance)
    {
        if (target == Target.Ally)
        {
            return alliance.type == GetComponentInParent<Alliance>().type;
        }
        else
        {
            return alliance.type != GetComponentInParent<Alliance>().type;
        }
    }
}
