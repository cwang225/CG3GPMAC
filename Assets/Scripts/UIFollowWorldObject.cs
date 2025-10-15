using UnityEngine;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/01/25
 * Summary: Script to position UI relative to world space of an object
 */
public class UIFollowWorldObject : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    private RectTransform _rectTransform;
    private Camera _mainCam;

    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _mainCam = Camera.main;
    }

    public void ChangeTarget(Transform newTarget)
    {
        target = newTarget;
        Vector3 screenPos = _mainCam.WorldToScreenPoint(target.position + offset);
        screenPos.z = 0;
        _rectTransform.position = screenPos;
    }
}