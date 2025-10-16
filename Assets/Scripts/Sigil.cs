using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/15/25
 * Date Last Updated: 10/15/25
 * Summary: Holds/displays the visual for a sigil
 */
public class Sigil : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    private GameObject _preview;

    public void Preview(Tile target)
    {
        // lower alpha for the preview
        if (_preview == null)
        {
            _preview = Instantiate(prefab, transform);

            SpriteRenderer sprite = _preview.GetComponent<SpriteRenderer>();
            sprite.color = new Color(1, 1, 1, 0.7f);        
        }

        _preview.transform.position = TileManager.TileToWorld(target.coord, target.elevation);
    }

    public void HidePreview()
    {
        if (_preview != null)
        {
            Destroy(_preview);
            _preview = null;
        }
    }

    public GameObject Place(Tile target)
    {
        // full alpha for the real deal
        GameObject obj = _preview;
        if (_preview == null)
        {
            obj = Instantiate(prefab, transform);
        }

        SpriteRenderer sprite = obj.GetComponent<SpriteRenderer>();
        sprite.color = Color.white;
        obj.transform.position = TileManager.TileToWorld(target.coord, target.elevation);

        _preview = null;

        return obj;
    }
}
