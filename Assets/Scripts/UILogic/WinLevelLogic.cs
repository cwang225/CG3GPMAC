using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevelLogic : MonoBehaviour
{
    public void goBack()
    {
        SceneManager.LoadScene("CarlyLevelSelection");
    }
}
