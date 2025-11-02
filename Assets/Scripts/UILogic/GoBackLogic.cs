using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoBackLogic : MonoBehaviour
{

    public Button menuButton;
    public Button exit;
    public Button keepPlaying;
    public Boolean panelIsOpen = false;
    public GameObject menuPanel;

    // Start is called before the first frame update
    void Start()
    {
        // menuButton.onClick.AddListener(() => buttonOnClick());
    }

    public void buttonOnClick()
    {
        menuPanel.SetActive(true);
    }

    public void goBackLevels()
    {
        SceneManager.LoadScene("CarlyLevelSelection");
    }

    public void KeepPlaying()
    {
        menuPanel.SetActive(false);
    }
}
