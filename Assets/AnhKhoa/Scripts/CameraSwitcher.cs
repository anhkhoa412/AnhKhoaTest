using UnityEngine;
using UnityEngine.UI;

public class CameraSwitcher : MonoBehaviour
{
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;
    public Button switchCamera;

    public bool isFirstPersonActive = true; // Flag to track the active camera

    private void Start()
    {
        // Make sure one camera is active at the start
        ActivateFirstPersonCamera();
    }

    public void OnSwitch()
    {
        ToggleCamera();
    }

    private void ToggleCamera()
    {
        // Toggle between the cameras
        if (isFirstPersonActive)
        {
            ActivateThirdPersonCamera();
        }
        else
        {
            ActivateFirstPersonCamera();
        }
    }

    private void ActivateFirstPersonCamera()
    {
        firstPersonCamera.gameObject.SetActive(true);
        thirdPersonCamera.gameObject.SetActive(false);   
        isFirstPersonActive = true; // Set the flag
    }

    private void ActivateThirdPersonCamera()
    {
        firstPersonCamera.gameObject.SetActive(false) ;
        thirdPersonCamera.gameObject.SetActive(true);
    
        isFirstPersonActive = false; // Set the flag
    }
}
