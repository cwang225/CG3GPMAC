using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
/**
 * Author: Megan Lincicum
 * Date Created: 10/01/25
 * Date Last Updated: 12/01/25
 * Summary: UI for an Ability Menu which holds options such as Move, Attack, etc. 
 */
public class AbilityMenuPanelController : MonoBehaviour
{
    const string EntryPoolKey = "AbilityMenuPanel.Entry";
    const int MenuCount = 4;
    
    [SerializeField] GameObject entryPrefab;
    [SerializeField] GameObject panel;
    [SerializeField] GameObject canvas;
    /* [SerializeField]*/ public AudioSource sfxHover;
    /* [SerializeField]*/
    public AudioSource sfxClick;
    public AudioSource sfxCancel;
    List<AbilityMenuEntry> menuEntries = new List<AbilityMenuEntry>(MenuCount);
    public int selection { get; private set; }

    public UnityEvent selectionConfirmed;
    
    void Awake ()
    {
        GameObjectPoolController.AddEntry(EntryPoolKey, entryPrefab, MenuCount, int.MaxValue);
    }

    void Start()
    {
        canvas.SetActive(false);
    }
    
    AbilityMenuEntry Dequeue ()
    {
        Poolable p = GameObjectPoolController.Dequeue(EntryPoolKey);
        AbilityMenuEntry entry = p.GetComponent<AbilityMenuEntry>();
        entry.transform.SetParent(panel.transform, false);
        entry.transform.localScale = Vector3.one;
        entry.gameObject.SetActive(true);
        entry.controller = this;
        entry.Reset();
        return entry;
    }

    void Enqueue (AbilityMenuEntry entry)
    {
        Poolable p = entry.GetComponent<Poolable>();
        GameObjectPoolController.Enqueue(p);
    }
    
    void Clear ()
    {
        for (int i = menuEntries.Count - 1; i >= 0; --i)
            Enqueue(menuEntries[i]);
        menuEntries.Clear();
    }
    
    public bool SetSelection (int value)
    {
        if (menuEntries[value].IsLocked)
            return false;
	
        // Deselect the previously selected entry
        if (selection >= 0 && selection < menuEntries.Count)
            menuEntries[selection].IsSelected = false;
	
        selection = value;

        // Select the new entry
        if (selection >= 0 && selection < menuEntries.Count)
            menuEntries[selection].IsSelected = true;
            sfxHover.Play();
	
        return true;
    }
    
    public void Next ()
    {
        for (int i = selection + 1; i < selection + menuEntries.Count; ++i)
        {
            int index = i % menuEntries.Count;
            if (SetSelection(index))
                break;
        }
    }
    public void Previous ()
    {
        for (int i = selection - 1 + menuEntries.Count; i > selection; --i)
        {
            int index = i % menuEntries.Count;
            if (SetSelection(index))
                break;
        }
    }
    
    public void Show (Transform target, List<string> options, bool[] lockedStates = null)
    {
        canvas.SetActive(false);
        Clear ();
        for (int i = 0; i < options.Count; ++i)
        {
            AbilityMenuEntry entry = Dequeue();
            entry.Title = options[i];
            entry.optionIndex = i;
            entry.Reset();
            
            if (lockedStates != null && i < lockedStates.Length)
                SetLocked(entry, i, lockedStates[i]);
            
            menuEntries.Add(entry);
        }
        
        selection = -1;
        Next();

        canvas.SetActive(true);
    }
    
    public void Hide ()
    {
        Clear();
        sfxCancel.Play();
        canvas.SetActive(false);
    }
    
    public void SetLocked (AbilityMenuEntry entry, int index, bool value)
    {
        if (entry == null)
            return;
        entry.IsLocked = value;
        if (value && selection == index)
            Next();
    }

    public void ConfirmSelection()
    {
        sfxClick.Play();
        selectionConfirmed.Invoke();
    }
}
