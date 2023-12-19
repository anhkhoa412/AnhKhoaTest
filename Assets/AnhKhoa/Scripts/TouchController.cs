using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour
{
    public FixedTouchField FixedTouchField;
    public CameraLook CameraLookFirstPerson; public CameraLook CameraLookThirdPerson;
    public PlayerMove PlayerMove;
    //public FixedButton FixedButton;
    public Transform target; // Reference to the camera transform

    void Start()
    {

    }


    void Update()
    {
        CameraLookFirstPerson.LockAxis = FixedTouchField.TouchDist;
        CameraLookThirdPerson.LockAxis = FixedTouchField.TouchDist;
       // PlayerMove.Pressed = FixedButton.Pressed;

        if (target != null)
        {
            // Get the target rotation from the camera
            Quaternion targetRotation = Quaternion.LookRotation(target.forward, Vector3.up);

            // Smoothly interpolate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation,1 * Time.deltaTime);
        }
    }
}
