using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{

    public FloatingJoystick joystick;
    public float SpeedMove = 5f;
    private CharacterController controller;
    [SerializeField] private Animator anim;

    private float Gravity = -9.81f;
    public float GroundDistance = 0.3f;
    public Transform Ground;
    public LayerMask layermask;
    Vector3 velocity;
    public float jumpheight = 3f;

    public bool isGround;
    public bool Pressed;

    void Start()
    {
        controller = GetComponent<CharacterController>();
      //  anim = GetComponent<Animator>();
    }


    void Update()
    {
        isGround = Physics.CheckSphere(Ground.position, GroundDistance, layermask);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }


        Vector3 Move = transform.right * joystick.Horizontal + transform.forward * joystick.Vertical;
        controller.Move(Move * SpeedMove * Time.deltaTime);


        if (isGround && Pressed)
        {
            velocity.y = Mathf.Sqrt(jumpheight * -2f * Gravity);
            isGround = false;
        }

        velocity.y += Gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            anim.SetBool("isRunning", true);
        }

        else if (joystick.Horizontal == 0 && joystick.Vertical == 0)
        {
            anim.SetBool("isRunning", false);
        }
    }
}
