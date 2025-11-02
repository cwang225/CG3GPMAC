using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
This file controls the level selection scene that allows users to see which level they can choose
*/

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
    int clicked = 0;
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
                levelsPanel.SetActive(false);
            }
            isLevelPanelActive = !isLevelPanelActive;
        }

    }

    public void buttonOnClick(int clickedOn)
    {
        playButton.SetActive(true);
        clicked = clickedOn;
    }

    // placeholder function to allow user to mimic going to the level selected
    public void goToLevel()
    {
        if (clicked == 0)
        {
            SceneManager.LoadScene("redPlanet");
        } else if (clicked == 1)
        {
            SceneManager.LoadScene("greenPlanet");
        } else if (clicked == 2)
        {
            SceneManager.LoadScene("orangePlanet");
        } else if (clicked == 3)
        {
            SceneManager.LoadScene("blackPlanet");
        } else if (clicked == 4)
        {
            SceneManager.LoadScene("bluePlanet");
        } else
        {
            SceneManager.LoadScene("purplePlanet");
        }
        
    }

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
