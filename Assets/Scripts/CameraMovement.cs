using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMovement : MonoBehaviour
{
    public Transform initTransform;
    public Unit targetUnit;
    public Alliance targetAlliance;
    public bool focusingOnAll;
    public int rotateSpeed;
    public float distance;
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        initTransform = gameObject.transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (focusingOnAll)
        {
            gameObject.transform.position = initTransform.position; // is this wasteful?
            return;
        }
        gameObject.transform.position = new Vector3(0,targetUnit.GetComponent<CapsuleCollider>().height,-distance);
        gameObject.transform.Rotate(0, angle, 0);
        gameObject.transform.Translate(targetUnit.transform.position);
    }
    public void OnChangeCameraPosition()
    {
        if (Input.GetButtonDown("Left Arrow"))
        {
            angle -= 10;
        }
        if (Input.GetButtonDown("Right Arrow"))
        {
            angle += 10;
        }
        if (Input.GetButtonDown("Up Arrow"))
        {
            if (distance > 1)
            {
                distance--;
            }
        }
        if (Input.GetButtonDown("Down Arrow"))
        {
            if (distance > 100)
            {
                distance++;
            }
        }
    }
    public void OnToggleCameraMode()
    {
        if (focusingOnAll)
        {
            focusingOnAll = false;
        } else {
            focusingOnAll = true;
        }
    }
}
