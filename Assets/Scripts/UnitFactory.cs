using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UnitFactory
{
    public static GameObject Create (UnitRecipe recipe)
    {
        GameObject obj = InstantiatePrefab("Units/" + recipe.model);
        obj.name = recipe.name;
        obj.AddComponent<Selectable>();
        obj.AddComponent<Unit>();
        AddAlliance(obj, recipe.alliance);
        AddMovement(obj, recipe.movementRange);
        AddStats(obj, recipe.health, recipe.mana);
        return obj;
    }
    
    static GameObject InstantiatePrefab (string name)
    {
        GameObject prefab = Resources.Load<GameObject>(name);
        if (prefab == null)
        {
            Debug.LogError("No Prefab for name: " + name);
            return new GameObject(name);
        }
        GameObject instance = GameObject.Instantiate(prefab);
        return instance;
    }
    
    static void AddAlliance (GameObject obj, Alliances type)
    {
        Alliance alliance = obj.AddComponent<Alliance>();
        alliance.type = type;
    }

    static void AddMovement(GameObject obj, int movementRange)
    {
       Movement movement = obj.AddComponent<Movement>();
       movement.range =  movementRange;
    }

    static void AddStats(GameObject obj, int maxHealth, int maxMana)
    {
        Health health = obj.AddComponent<Health>();
        Mana mana =  obj.AddComponent<Mana>();
        health.maxHealth = maxHealth;
        mana.maxMana = maxMana;
    }
}
