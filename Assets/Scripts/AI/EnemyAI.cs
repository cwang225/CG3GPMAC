using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/31/25
 * Date Last Updated: 10/31/25
 * Summary: a base class for enemy AI which chooses an action to perform
 */
public abstract class EnemyAI : MonoBehaviour
{
    protected Turn enemy;
    protected Movement movement;
    protected Ability baseAttack;
    protected AbilityCatalog catalog;

    protected string actionType; //todo: change to enum or something better
    protected Tile actionTarget;

    private void Start()
    {
        enemy = GetComponent<Turn>();
        movement = GetComponent<Movement>();
        baseAttack =  GetComponentInChildren<Ability>();
        catalog = GetComponentInChildren<AbilityCatalog>();
    }
    
    public abstract void PlanNextAction(TileManager tileManager);

    public string GetActionType()
    {
        return actionType;
    }

    public Tile GetActionTarget()
    {
        return actionTarget;
    }
    
}
