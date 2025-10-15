using System.Collections.Generic;
using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/15/25
 * Date Last Updated: 10/15/25
 * Summary: A class used to wrap the different parts of an ability (range, effect, target) and perform helpful functions
 */
public class Ability : MonoBehaviour
{
    public int manaCost;
    private Mana _mana;

    private AbilityRange _range;
    private AbilityArea _area;
    private AbilityEffectTarget _targeter;
    private AbilityEffect _effect;

    [HideInInspector] public List<Tile> tilesInArea;
    [HideInInspector] public List<Tile> targetsInArea;


    private void Awake()
    {
        _range = GetComponent<AbilityRange>();
        _area = GetComponent<AbilityArea>();
        _targeter = GetComponent<AbilityEffectTarget>();
        _effect = GetComponent<AbilityEffect>();
    }

    private void Start()
    {
        _mana = GetComponentInParent<Mana>();
    }

    public List<Tile> GetTilesInRange(TileManager tileManager)
    {
        return _range.GetTilesInRange(tileManager);
    }

    public List<Tile> GetTilesInArea(TileManager tileManager, Tile target)
    {
        return _area.GetTilesInArea(tileManager, target);
    }

    public List<Tile> GetTargetsInArea(List<Tile> tiles)
    {
        List<Tile> ret = new List<Tile>();
        for (int i = 0; i < tiles.Count; i++)
        {
            if (_targeter.IsTarget(tiles[i]))
                ret.Add(tiles[i]);
        }
        return ret;
    }

    public bool CanPerform()
    {
        return _mana.currentMana >= manaCost;
    }

    public void Perform()
    {
        for (int i = 0; i < targetsInArea.Count; i++)
            _effect.Apply(targetsInArea[i]);

        _mana.Drain(manaCost);
    }
}
