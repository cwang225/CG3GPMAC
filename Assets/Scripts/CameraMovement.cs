using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

// This script is used to manipulate the camera in-game.
// Currently its parameters are only accessible via the inspector, i.e.
// there is not yet an in-game UI that interfaces with this.
public class CameraMovement : MonoBehaviour
{   
    // The initial position of the camera, as in before the game starts.
    public Vector3 initTransformPos;
    // The initial rotation of the camera.
    public Quaternion initTransformRot;
    // The unit towards which to focus the camera
    public Unit targetUnit;
    // (unused - edit this if this changes)
    public Alliance targetAlliance;
    // Whether the camera is focusing on a unit or the whole scene
    public bool focusingOnAll;
    // The speed at which to rotate around the player as the input button is held (currently unused)
    public int rotateSpeed;
    // The distance from the target unit to hover.
    public float distance;
    // The angle from which to view the target player.
    public float angle;
    // Start is called before the first frame update
    void Start()
    {
        initTransformPos = gameObject.transform.position;
        initTransformRot = gameObject.transform.rotation;

    }

    // Update is called once per frame
    void Update()
    {
        if (focusingOnAll)
        {
            gameObject.transform.position = initTransformPos; // is this wasteful?
            gameObject.transform.rotation = initTransformRot;
            return;
        }
        /* gameObject.transform.rotation = new Quaternion(0, 0, 0, 0);
        gameObject.transform.position = new Vector3(-distance,targetUnit.GetComponent<CapsuleCollider>().height,0);
        gameObject.transform.Rotate(0, angle, 0);
        gameObject.transform.Translate(targetUnit.transform.position); */

        gameObject.transform.position = targetUnit.gameObject.transform.position;
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.Translate(0, 0, -distance);
        gameObject.transform.RotateAround(targetUnit.gameObject.transform.position, Vector3.up, angle);
        // gameObject.transform.Rotate(0, angle, 0);

        /*gameObject.transform.position = new Vector3(0, 0, 0);
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        gameObject.transform.Translate(0, 0, distance);
        gameObject.transform.RotateAround */

    }
    // TODO: look into how to get held input with the new input system
    // also: make an in-inspector GUI
    /* public void OnChangeCameraPosition()
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
    } */
    public void OnToggleCameraMode()
    {
        if (focusingOnAll)
        {
            focusingOnAll = false;
        }
        else
        {
            focusingOnAll = true;
        }
    }
}
