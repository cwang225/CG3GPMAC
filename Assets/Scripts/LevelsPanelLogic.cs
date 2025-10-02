using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelsPanelLogic : MonoBehaviour
{
    // Gameobject for the entire panel
    public GameObject levelsPanel;

    // Buttons for the levels
    public Button levelButton1;
    public Button levelButton2;
    public Button levelButton3;
    public Button levelButton4;
    public Button levelButton5;
    public Button levelButton6;
    
    //play button for the next scene
    public GameObject playButton;
    Boolean isLevelPanelActive = false;
    private Button[] buttons = new Button[6];

    // Start is called before the first frame update
    // all buttons and their objects in the scene are grabbed ans assigned a button in the script
    void Start()
    {
        buttons[0] = levelButton1;
        buttons[1] = levelButton2;
        buttons[2] = levelButton3;
        buttons[3] = levelButton4;
        buttons[4] = levelButton5;
        buttons[5] = levelButton6;

        // all buttons are assigned a listener so that buttons can detect when they are being pressed
        levelButton1.onClick.AddListener(() => buttonOnClick(0));
        levelButton2.onClick.AddListener(() => buttonOnClick(1));
        levelButton3.onClick.AddListener(() => buttonOnClick(2));
        levelButton4.onClick.AddListener(() => buttonOnClick(3));
        levelButton5.onClick.AddListener(() => buttonOnClick(4));
        levelButton6.onClick.AddListener(() => buttonOnClick(5));
        // Debug.Log(buttons.Length);
    }

    // Update is called once per frame
    // Update is called to control what shows up on the scene; pressing X pulls up the level selection screen
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (!isLevelPanelActive)
            {
                levelsPanel.SetActive(true);

            }
            else
            {
                buttonOnClick(7);
                levelsPanel.SetActive(false);
            }
            isLevelPanelActive = !isLevelPanelActive;
        }

    }

    // The function that is called by the listener added to all buttons
    // makes sure that when a button is pressed, it is the only button with its outline active
    // also sets the play level button active
    public void buttonOnClick(int index)
    {
        Debug.Log(index);
        for (int i = 0; i < buttons.Length; i++)
        {
            if (index != i)
            {
                buttons[i].GetComponent<Outline>().enabled = false;
            }
            else
            {
                buttons[i].GetComponent<Outline>().enabled = true;
                playButton.SetActive(true);
            }
        }
    }

    // placeholder function to allow user to mimic going to the level selected
    public void goToLevel()
    {
        SceneManager.LoadScene("Megan");
        Debug.Log("going to new level :3");
    }

    // makes sure to destroy all listerners on all buttons
    void OnDestroy()
    {
        levelButton1.onClick.RemoveAllListeners();
        levelButton2.onClick.RemoveAllListeners();
        levelButton3.onClick.RemoveAllListeners();
        levelButton4.onClick.RemoveAllListeners();
        levelButton5.onClick.RemoveAllListeners();
        levelButton6.onClick.RemoveAllListeners();
    }

}
