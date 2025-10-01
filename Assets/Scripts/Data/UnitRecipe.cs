using UnityEngine;

[CreateAssetMenu(menuName = "Tactics/Unit Recipe", fileName = "NewUnitRecipe")]
public class UnitRecipe : ScriptableObject
{
    public string model;
    public int movementRange;
    public int health;
    public int mana;
    public Alliances alliance;
}
