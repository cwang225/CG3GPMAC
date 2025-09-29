using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SelectActionState : BattleState
{
    protected override void HandleMoveSelection(InputAction.CallbackContext context)
    {
        print("OnMoveSelection SelectActionState");
    }
    
    protected override void HandleSelect(InputAction.CallbackContext context)
    {
        print("OnSelect SelectActionState");
    }
}
