using System.Collections.Generic;
using UnityEngine.InputSystem;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 10/01/25
 * Summary: Base state for the BattleController
 */
public abstract class BattleState : State
{
    protected BattleController owner;
    public TileManager tileManager { get { return owner.tileManager; } }
    public LevelData levelData { get { return owner.levelData; } }
    public List<Unit> units { get { return owner.units; } }
    public AbilityMenuPanelController abilityMenuPanelController { get { return owner.abilityMenuPanelController; }}
    
    public Tile HoveredTile => tileManager.HoveredTile;
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
        playerInput.actions["Click"].performed += HandleClick;
    }
	
    protected override void RemoveListeners ()
    {
        playerInput.actions["MoveSelection"].performed -= HandleMoveSelection;
        playerInput.actions["Select"].performed -= HandleSelect;
        playerInput.actions["Cancel"].performed -= HandleCancel;
        playerInput.actions["Click"].performed -= HandleClick;
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
    
    protected virtual void HandleClick(InputAction.CallbackContext context)
    {
        
    }
    
}
