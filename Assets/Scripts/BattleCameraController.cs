using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;
/**
 * Author: Megan Lincicum
 * Date Created: 11/14/25
 * Date Last Updated: 11/14/25
 * Summary: Controls the camera and switches between free mode and following a unit
 */
public class BattleCameraController : MonoBehaviour
{
    [Header("Cinemachine VCs")]
    public CinemachineVirtualCamera freeCam;
    public CinemachineVirtualCamera followCam;

    [Header("Pan/Zoom Settings")]
    public float panSpeed = 10f;
    public float zoomSpeed = 5f;
    public float minZoom = 5f;
    public float maxZoom = 20f;

    private Vector2 panInput;
    private float zoomInput;

    private Transform targetUnit;

    private PlayerInput playerInput;

    private void Awake()
    {
        playerInput= GetComponent<PlayerInput>();

    }

    // Input
    public void OnPanCamera() { panInput = playerInput.actions["PanCamera"].ReadValue<Vector2>(); }
    public void OnZoomCamera() { zoomInput = playerInput.actions["ZoomCamera"].ReadValue<float>(); }


    void Update()
    {
        HandleFreeCameraMovement();
    }

    private void HandleFreeCameraMovement()
    {
        if (!freeCam.gameObject.activeInHierarchy) return;

        // Pan camera horizontally
        Vector3 move = new Vector3(panInput.x, 0, panInput.y);
        freeCam.transform.position += move * panSpeed * Time.deltaTime;

        // Zoom camera
        if (Mathf.Abs(zoomInput) > 0.01f)
        {
            var lens = freeCam.m_Lens;
            lens.FieldOfView -= zoomInput * zoomSpeed;
            lens.FieldOfView = Mathf.Clamp(lens.FieldOfView, minZoom, maxZoom);
            freeCam.m_Lens = lens;
        }
    }

    // Snap / follow unit
    public void SetFollowTarget(Transform unit)
    {
        targetUnit = unit;

        //followCam.gameObject.SetActive(true);
        //freeCam.gameObject.SetActive(false);

        freeCam.Follow = targetUnit;
        freeCam.LookAt = targetUnit;
    }

    public void ReturnToFreeCamera()
    {
        //followCam.gameObject.SetActive(false);
        //freeCam.gameObject.SetActive(true);
        freeCam.Follow = null;
        freeCam.LookAt = null;
    }
}
