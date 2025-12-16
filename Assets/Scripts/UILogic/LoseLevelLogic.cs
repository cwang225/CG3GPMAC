using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseLevelLogic : MonoBehaviour
{
    public void retry()
    {
        Debug.Log("clicked retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void goBack()
    {
        Debug.Log("clicked goback");
        SceneManager.LoadScene("LevelSelectionPanel");
    }
}
