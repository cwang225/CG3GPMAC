using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AbilityMenuEntry : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label;
    
    public string Title
    {
        get { return label.text; }
        set { label.text = value; }
    }
    
    enum States
    {
        None,
        Selected,
        Locked 
    }
    
    public bool IsLocked
    {
        get => (State == States.Locked);
        set
        {
            State = States.Locked;
        }
    }
    public bool IsSelected
    {
        get => (State == States.Selected);
        set
        {
            State = States.Locked;
        }
    }
    States State
    { 
        get { return _state; }
        set
        {
            if (_state == value)
                return;
            _state = value;
		
            if (IsLocked)
            {
                // lock the button and make the text grey
            }
            else if (IsSelected)
            {
                // unlock the button and make the text yellow
            }
            else
            {
                // unlock the button make the text default
            }
        }
    }
    States _state;

    public void Reset()
    {
        State = States.None;
    }
}
