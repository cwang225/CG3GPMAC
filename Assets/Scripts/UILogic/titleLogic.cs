using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class titleLogic : MonoBehaviour
{
    public Button playBtn;
    // Start is called before the first frame update
    public void startGame()
    {
        SceneManager.LoadScene("CarlyLevelSelection");
    }
}
