using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Assertions;

public class LevelGater : MonoBehaviour
{
    public GameObject levelOneButton;
    public GameObject levelOneChains;
    public GameObject levelTwoButton;
    public GameObject levelTwoChains;
    public GameObject levelThreeButton;
    public GameObject levelThreeChains;
    public GameObject levelFourButton;
    public GameObject levelFourChains;
    public GameObject levelFiveButton;
    public GameObject levelFiveChains;
    public GameObject levelSixButton;
    public GameObject GameProgressManager;
    // Start is called before the first frame update
    void Update()
    {
        var gpm = GameProgressManager.GetComponent<GameProgressManager>();
        if (gpm.levelCompleteStates[0])
        {
            levelOneButton.GetComponent<Image>().raycastTarget = true;
            levelOneButton.GetComponent<Button>().interactable = true;
            levelOneChains.SetActive(false);
        }
        else
        {
            levelOneButton.GetComponent<Image>().raycastTarget = false;
            levelOneButton.GetComponent<Button>().interactable = false;
            levelOneChains.SetActive(true);
        }
        if (gpm.levelCompleteStates[1])
        {
            levelTwoButton.GetComponent<Image>().raycastTarget = true;
            levelTwoButton.GetComponent<Button>().interactable = true;
            levelTwoChains.SetActive(false);
        } else
        {
            levelTwoButton.GetComponent<Image>().raycastTarget = false;
            levelTwoButton.GetComponent<Button>().interactable = false;
            levelTwoChains.SetActive(true);
        }

        if (gpm.levelCompleteStates[2])
        {
            levelThreeButton.GetComponent<Image>().raycastTarget = true;
            levelThreeButton.GetComponent<Button>().interactable = true;
            levelThreeChains.SetActive(false);
        } else
        {
            levelThreeButton.GetComponent<Image>().raycastTarget = false;
            levelThreeButton.GetComponent<Button>().interactable = false;
            levelThreeChains.SetActive(true);
        }

        if (gpm.levelCompleteStates[3])
        {
            levelFourButton.GetComponent<Image>().raycastTarget = true;
            levelFourButton.GetComponent<Button>().interactable = true;
            levelFourChains.SetActive(false);
        } else
        {
            levelFourButton.GetComponent<Image>().raycastTarget = false;
            levelFourButton.GetComponent<Button>().interactable = false;
            levelFourChains.SetActive(true);
        }

        if (gpm.levelCompleteStates[4])
        {
            levelFiveButton.GetComponent<Image>().raycastTarget = true;
            levelFiveButton.GetComponent<Button>().interactable = true;
            levelFiveChains.SetActive(false);
        } else
        {
            levelFiveButton.GetComponent<Image>().raycastTarget = false;
            levelFiveButton.GetComponent<Button>().interactable = false;
            levelFiveChains.SetActive(true);
        }

        if (gpm.levelCompleteStates[5])
        {
            levelSixButton.GetComponent<Image>().raycastTarget = true;
            levelSixButton.GetComponent<Button>().interactable = true;
            levelSixButton.SetActive(true);
        } else
        {
            levelSixButton.GetComponent<Image>().raycastTarget = false;
            levelSixButton.GetComponent<Button>().interactable = false;
            levelSixButton.SetActive(false);
        }
    }
}
