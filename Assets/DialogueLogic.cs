using TMPro;
using UnityEngine;

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
        }, // level 1 start (0)
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
        }, // level 1 win (1)
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "Fall back, fall back!"
                },
            }
        }, // level 1 fail (2)
        new DialogueSequence
        {
            entries =
            new DialogueEntry[]{
                // dialogue 0: generic start of battle
                new DialogueEntry
                {
                    text = "placeholder level 2 start dialogue"
                },
            },
        }, // level 2 start (3)
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "level 2 win dialogue"
                },
                new DialogueEntry
                {
                    text = "replace for final submission"
                },
            }
        }, // level 2 win (4)
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "Fall back, fall back!"
                },
            }
        }, // level 2 fail (5)
        new DialogueSequence
        {
            entries =
            new DialogueEntry[]{
                // dialogue 0: generic start of battle
                new DialogueEntry
                {
                    text = "placeholder level 3 start dialogue"
                },
            },
        }, // level 3 start (6)
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "level 3 win dialogue"
                },
                new DialogueEntry
                {
                    text = "replace for final submission"
                },
            }
        }, // level 3 win (7)
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "Fall back, fall back!"
                },
            }
        }, // level 3 fail (8)
        new DialogueSequence
        {
            entries =
            new DialogueEntry[]{
                // dialogue 0: generic start of battle
                new DialogueEntry
                {
                    text = "placeholder level 4 start dialogue"
                },
            },
        }, // level 4 start (9)
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "level 4 win dialogue"
                },
                new DialogueEntry
                {
                    text = "replace for final submission"
                },
            }
        }, // level 4 win (10)
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "Fall back, fall back!"
                },
            }
        }, // level 4 fail (11)
        new DialogueSequence
        {
            entries =
            new DialogueEntry[]{
                // dialogue 0: generic start of battle
                new DialogueEntry
                {
                    text = "placeholder level 5 start dialogue"
                },
            },
        }, // level 5 start (12)
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "level 5 win dialogue"
                },
                new DialogueEntry
                {
                    text = "replace for final submission"
                },
            }
        }, // level 5 win (13)
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "Fall back, fall back!"
                },
            }
        }, // level 5 fail (14)
       
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "level 6 start dialogue"
                },
                new DialogueEntry
                {
                    text = "replace for final submission"
                },
            }
        }, // level 6 start (15)
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "level 6 win dialogue"
                },
                new DialogueEntry
                {
                    text = "replace for final submission"
                },
            }
        }, // level 6 win (16)
        new DialogueSequence
        {
            entries = new DialogueEntry[]
            {
                new DialogueEntry
                {
                    text = "Fall back, fall back!"
                },
            }
        } // level 6 fail (17)
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
        // sequence 0 (start of battle on level 1)
        // print("headshot: " + dialogueSequences[0].entries[0].headshot);
        dialogueSequences[0].entries[0].headshot = Resources.Load<Sprite>("muraPFP");
        dialogueSequences[0].entries[1].headshot = Resources.Load<Sprite>("enemyPFP");
        dialogueSequences[0].entries[2].headshot = Resources.Load<Sprite>("muraPFP");
        dialogueSequences[0].entries[3].headshot = Resources.Load<Sprite>("enemyPFP");

        // victory on level 1
        dialogueSequences[1].entries[0].headshot = Resources.Load<Sprite>("muraPFP");
        dialogueSequences[1].entries[1].headshot = Resources.Load<Sprite>("muraPFP");
        
        // loss on level 1
        dialogueSequences[2].entries[0].headshot = Resources.Load<Sprite>("nyanzuPFP");

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
