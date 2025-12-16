using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
/**
 * Author: Megan Lincicum
 * Date Created: 10/15/25
 * Date Last Updated: 10/15/25
 * Summary: UI to prompt the user to end turn or not (PLACEHOLDER CODE)
 */
public class EndTurnDialog : MonoBehaviour
{
    [SerializeField] GameObject dialog;
    [SerializeField] Button endTurnButton;
    [SerializeField] Button cancelButton;
    public void Show()
    {
        dialog.SetActive(true);
    }

    public void Hide()
    {
        dialog.SetActive(false);
    }

    public void HookupEndTurn(UnityAction listener)
    {
        Debug.Log("clicked end turn btn");
        endTurnButton.onClick.AddListener(listener);
    }

    public void HookupCancel(UnityAction listener)
    {
        Debug.Log("clicked cancel turn btn");
        cancelButton.onClick.AddListener(listener);
    }
}
