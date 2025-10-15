using System.Linq;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/15/25
 * Summary: Static class to instantiate Units with all the proper components based off their recipe (data)
 */
public static class UnitFactory
{
    public static GameObject Create (UnitRecipe recipe)
    {
        GameObject obj = InstantiatePrefab("Units/" + recipe.model);
        obj.name = recipe.name;
        obj.AddComponent<Selectable>();
        obj.AddComponent<Unit>();
        obj.AddComponent<Turn>();
        AddAlliance(obj, recipe.alliance);
        AddMovement(obj, recipe.movementRange);
        AddStats(obj, recipe.health, recipe.mana);
        AddAttack(obj, recipe.baseAttackRanged);
        AddAbilities(obj, recipe.abilities);
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

    static void AddAttack(GameObject obj, bool isRanged)
    {
        string name = isRanged ? "BaseRanagedAttack" : "BaseMeleeAttack";
        GameObject instance = InstantiatePrefab("Abilities/" + name);
        instance.name = name;
        instance.transform.SetParent(obj.transform);
    }

    static void AddAbilities(GameObject obj, string[] abilities)
    {
        GameObject catalog = new GameObject("Ability Catalog");
        catalog.transform.SetParent(obj.transform);
        catalog.AddComponent<AbilityCatalog>();

        for (int i = 0; i < abilities.Count(); i++)
        {
            string abilityName = abilities[i];
            GameObject ability = InstantiatePrefab("Abilities/" + abilityName);
            ability.name = abilityName;
            ability.transform.SetParent(catalog.transform);
        }
    }
}
