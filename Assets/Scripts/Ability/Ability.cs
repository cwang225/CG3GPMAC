using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
/**
 * Author: Megan Lincicum
 * Date Created: 10/15/25
 * Date Last Updated: 10/30/25
 * Summary: A class used to wrap the different parts of an ability (range, effect, target) and perform helpful functions
 */
public class Ability : MonoBehaviour
{
    [Header("Cost")]
    public int manaCost;
    private Mana _mana;

    [Header("Highlight Color")]
    public Color highlightColor;

    private AbilityRange _range;
    private AbilityArea _area;
    private AbilityEffectTarget[] _targeters;
    private AbilityEffect _effect;
    private AbilityParticle _particle;
    private Sigil _sigil;
    [HideInInspector] public bool isSigil => _sigil != null;

    [HideInInspector] public List<Tile> tilesInArea;
    [HideInInspector] public List<Tile> targetsInArea;


    private void Awake()
    {
        _range = GetComponent<AbilityRange>();
        _area = GetComponent<AbilityArea>();
        _targeters = GetComponents<AbilityEffectTarget>();
        _effect = GetComponent<AbilityEffect>();
        _particle = GetComponent<AbilityParticle>();
        _sigil = GetComponent<Sigil>();
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
            if (IsTarget(tiles[i]))
                ret.Add(tiles[i]);
        }
        return ret;
    }

    private bool IsTarget(Tile target)
    {
        for (int i = 0; i < _targeters.Length; i++)
        {
            if (!_targeters[i].IsTarget(target))
                return false;
        }
        return true;
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

    public IEnumerator Animate(Tile target)
    {
        if (_particle != null)
        {
            _particle.Play(target);
            yield return new WaitForSeconds(_particle.animationTime + 0.5f);
        }

        else if (isSigil)
        {
            // this will depend on how we want to handle sigils
            GameObject sigil = PlaceSigil(target);
            yield return new WaitForSeconds(1f);
            Destroy(sigil);
        }

        else
        {
            yield return new WaitForSeconds(0.5f);
        }
        
    }

    public void PreviewSigil(Tile target)
    {
        if (!isSigil)
            return;
        _sigil.Preview(target);
    }

    public void HideSigil()
    {
        if (!isSigil)
            return;
        _sigil.HidePreview();
    }

    public GameObject PlaceSigil(Tile target)
    {
        if (!isSigil)
            return null;
        return _sigil.Place(target);
    }
}
