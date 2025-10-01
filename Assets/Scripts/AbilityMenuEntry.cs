using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.XR;
using UnityEngine.UI;

public class AbilityMenuEntry : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] Button button;

    [SerializeField] Color selectedColor;
    [SerializeField] Color defaultColor;

    public int optionIndex;
    public AbilityMenuPanelController controller;

    public string Title
    {
        get { return label.text; }
        set { label.text = value; }
    }

    [System.Flags]
    enum States
    {
        None = 0,
        Selected = 1 << 0,
        Locked = 1 << 1
    }

    public bool IsLocked
    {
        get { return (State & States.Locked) != States.None; }
        set
        {
            if (value)
            {
                State |= States.Locked;
                button.interactable = false;
            }
            
            else
            {
                State &= ~States.Locked;
                button.interactable = true;
            }
        }
    }

    public bool IsSelected
    {
        get { return (State & States.Selected) != States.None; }
        set
        {
            if (value)
                State |= States.Selected;
            else
                State &= ~States.Selected;
        }
    }

    States State
    {
        get { return state; }
        set
        {
            if (state == value)
                return;
            state = value;

            if (IsLocked)
            {
                // make text grey
                label.color = defaultColor;
            }
            else if (IsSelected)
            {
                // make text yellow
                label.color = selectedColor;
            }
            else
            {
                // make text default
                label.color = defaultColor;
            }
        }
    }
    States state;

    public void Reset()
    {
        State = States.None;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        controller.SetSelection(optionIndex);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        controller.ConfirmSelection();
    }
}
