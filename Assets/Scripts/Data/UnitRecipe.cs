using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/15/25
 * Summary: Scriptable Object to hold data about a type of unit
 */
[CreateAssetMenu(menuName = "Tactics/Unit Recipe", fileName = "NewUnitRecipe")]
public class UnitRecipe : ScriptableObject
{
    public string model;
    public Alliances alliance;
    public int movementRange;
    public int health;
    public int mana;
    public bool baseAttackRanged;
    public string[] abilities;
}
