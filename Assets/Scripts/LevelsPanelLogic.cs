using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelsPanelLogic : MonoBehaviour
{
    public GameObject levelsPanel;
    public GameObject levelPanel1;
    public GameObject levelPanel2;
    public GameObject levelPanel3;
    public GameObject levelPanel4;
    public GameObject levelPanel5;
    public GameObject levelPanel6;
    public int currKey = (int)KeyCode.Alpha1; // keycode for 1
    Boolean isLevelPanelActive = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
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
        // else if (Input.GetKeyDown(KeyCode) && (int)KeyCode.Alpha1 == currKey)
        // {
            
        // }
    }

    void goToLevel()
    {
        Debug.Log("going to new level :3");
    }
}
