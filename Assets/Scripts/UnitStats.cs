using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    private string unitName;
    
    private int health;
    private int maxHealth;
    private int mana;
    private int maxMana;

    private int moveSpeed;

    public UnitStats(string unitName, int maxHealth, int maxMana, int moveSpeed)
    {
        this.unitName = unitName;
        this.maxHealth = maxHealth;
        health = maxHealth;
        this.maxMana = maxMana;
        mana = maxMana;
        this.moveSpeed = moveSpeed;
    }
}
