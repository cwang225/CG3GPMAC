using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/15/25
 * Date Last Updated: 10/15/25
 * Summary: A base class for the effect of an ability (ie damage, status effect, heal)
 */
public abstract class AbilityEffect : MonoBehaviour
{
    public abstract int Predict(Tile target);
    public abstract void Apply(Tile target);
}
