using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public abstract class BattleState : State
{
    protected BattleController owner;
    public TileManager tileManager { get { return owner.tileManager; } }
    public LevelData levelData { get { return owner.levelData; } }
    
    private PlayerInput playerInput;

    protected virtual void Awake()
    {
        owner = GetComponent<BattleController>();
        playerInput = GetComponent<PlayerInput>();
    }
    
    protected override void AddListeners ()
    {
        playerInput.actions["MoveSelection"].performed += HandleMoveSelection;
        playerInput.actions["Select"].performed += HandleSelect;
        playerInput.actions["Cancel"].performed += HandleCancel;
    }
	
    protected override void RemoveListeners ()
    {
        playerInput.actions["MoveSelection"].performed -= HandleMoveSelection;
        playerInput.actions["Select"].performed -= HandleSelect;
        playerInput.actions["Cancel"].performed -= HandleCancel;
    }

    protected virtual void HandleMoveSelection(InputAction.CallbackContext context)
    {
        
    }

    protected virtual void HandleSelect(InputAction.CallbackContext context)
    {
        
    }

    protected virtual void HandleCancel(InputAction.CallbackContext context)
    {
        
    }
    
    
}
