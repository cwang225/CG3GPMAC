using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelLogic : MonoBehaviour
{
    public GameObject panelToControl;
    private bool isPanelToControlActive = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (!isPanelToControlActive)
            {
                panelToControl.SetActive(true);

            }
            else
            {
                panelToControl.SetActive(false);
            }
            isPanelToControlActive = !isPanelToControlActive;
        }
    }

    public void FunctionToExecute()
    {
        Debug.Log("Go back");
    }
}
