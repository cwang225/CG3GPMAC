using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using Mono.Cecil.Cil;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueLogic : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject dialog;
    // [SerializeField] Button nextDialogueEntryButton;
    [SerializeField] GameObject displayedText; // has TextMeshPro - Text (UI)
    [SerializeField] GameObject displayedHeadshot; // has Image

    public DialogueSequence currentDialogueSequence;
    public int currentDialogueEntry;
    bool hack;
    public struct DialogueSequence
    {
        public DialogueEntry[] entries;
    }
    public struct DialogueEntry
    {

        public Sprite headshot;
        public string text;

    }
    DialogueSequence[] dialogueSequences = {
        new DialogueSequence
        {
            entries =
            new DialogueEntry[]{
                // dialogue 0: generic start of battle
                new DialogueEntry
                {
                    text = "Oh, shoot. They didn't tell us we'd have company..."
                },
                new DialogueEntry
                {
                    text = "I thought we saw something on the radar. What do you want exactly?"
                },
                new DialogueEntry
                {
                    text = "What's it to you? Our business is ours alone."
                },
                new DialogueEntry
                {
                    text = "Very well. We'll consider this an invasion."
                },
            },
        },
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "Is everyone alright? That was intense."
                },
                new DialogueEntry
                {
                    text = "One planet down, four to go I guess..."
                },
            }
        },
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "Fall back, fall back!"
                },
            }
        }
    };

    public void Show()
    {
        currentDialogueEntry = 0;
        nextDialogueEntryOrHide();
        dialog.SetActive(true);
    }
    
    public void ShowWithDialogueSequence(int n)
    {
        UnityEngine.Assertions.Assert.IsTrue(n > 0);
        UnityEngine.Assertions.Assert.IsTrue(n < dialogueSequences.GetLength(0));

        currentDialogueSequence = dialogueSequences[n];
        Show();
    }

    public void Hide()
    {
        dialog.SetActive(false);
    }

    public void setDialogueSequence(int x)
    {
        currentDialogueSequence = dialogueSequences[x];
    }

    public void nextDialogueEntryOrHide()
    {

        print(currentDialogueSequence.entries);
        if (currentDialogueEntry == currentDialogueSequence.entries.GetLength(0)) // length is correct
        {
            print(currentDialogueEntry);
            Hide();
            return;
        }
        var imagecomp = displayedHeadshot.GetComponent<UnityEngine.UI.Image>();
        imagecomp.sprite = currentDialogueSequence.entries[currentDialogueEntry].headshot;
        var textcomp = displayedText.GetComponent<TextMeshProUGUI>();
        print(textcomp);
        print(currentDialogueSequence.entries[currentDialogueEntry]);
        print(currentDialogueSequence.entries[currentDialogueEntry].text);
        textcomp.text = currentDialogueSequence.entries[currentDialogueEntry].text;
        currentDialogueEntry++;

    }
    void Start()
    {
        // sequence 0 (start of battle)
        // print("headshot: " + dialogueSequences[0].entries[0].headshot);
        dialogueSequences[0].entries[0].headshot = Resources.Load<Sprite>("muraPFP");
        dialogueSequences[0].entries[1].headshot = Resources.Load<Sprite>("enemyPFP");
        dialogueSequences[0].entries[2].headshot = Resources.Load<Sprite>("muraPFP");
        dialogueSequences[0].entries[3].headshot = Resources.Load<Sprite>("enemyPFP");

        dialogueSequences[1].entries[0].headshot = Resources.Load<Sprite>("muraPFP");
        dialogueSequences[1].entries[1].headshot = Resources.Load<Sprite>("muraPFP");
        

        currentDialogueEntry = 0;
        print(dialogueSequences[0]);
        currentDialogueSequence = dialogueSequences[0];
        Show();
    }
    // test
    // Update is called once per frame
    void Update()
    {
        /* if (hack) {
            nextDialogueEntryButton.onClick.AddListener(nextDialogueEntryOrHide);
            hack = false;
        } */
    }

    /* public class ClickDebug : MonoBehaviour, IPointerClickHandler
    {
        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log("Clicked: " + gameObject.name);
        }
    } */
}
