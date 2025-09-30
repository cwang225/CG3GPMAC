using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelsPanelLogic : MonoBehaviour
{
    public GameObject levelsPanel;
    public Button levelButton1;
    public Button levelButton2;
    public Button levelButton3;
    public Button levelButton4;
    public Button levelButton5;
    public Button levelButton6;
    public GameObject playButton;
    // public int currKey = (int)KeyCode.Alpha1; // keycode for 1
    Boolean isLevelPanelActive = false;
    private Button[] buttons = new Button[6];
    // Start is called before the first frame update
    void Start()
    {
        buttons[0] = levelButton1;
        buttons[1] = levelButton2;
        buttons[2] = levelButton3;
        buttons[3] = levelButton4;
        buttons[4] = levelButton5;
        buttons[5] = levelButton6;
        // levelButton1.onClick.AddListener(() => buttonOnClick(0));
        // levelButton2.onClick.AddListener(() => buttonOnClick(1));
        // levelButton3.onClick.AddListener(() => buttonOnClick(2));
        // levelButton4.onClick.AddListener(() => buttonOnClick(3));
        // levelButton5.onClick.AddListener(() => buttonOnClick(4));
        // levelButton6.onClick.AddListener(() => buttonOnClick(5));
        levelButton1.onClick.AddListener(() => buttonOnClick(0));
        levelButton2.onClick.AddListener(() => buttonOnClick(1));
        levelButton3.onClick.AddListener(() => buttonOnClick(2));
        levelButton4.onClick.AddListener(() => buttonOnClick(3));
        levelButton5.onClick.AddListener(() => buttonOnClick(4));
        levelButton6.onClick.AddListener(() => buttonOnClick(5));
        Debug.Log(buttons.Length);
    }

    // Update is called once per frame
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
    public void goToLevel()
    {

        Debug.Log("going to new level :3");
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
