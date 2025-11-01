using System;
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

    private void Awake()
    {
        enemy = GetComponent<Turn>();
        movement = GetComponent<Movement>();
        
    }
    public abstract Ability GetNextAction();
}
