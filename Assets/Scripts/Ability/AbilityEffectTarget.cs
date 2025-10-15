using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/14/25
 * Date Last Updated: 10/14/25
 * Summary: A base class that determines what an ability can target 
 */
public abstract class AbilityEffectTarget : MonoBehaviour
{
    public abstract bool IsTarget(Tile target);
}
