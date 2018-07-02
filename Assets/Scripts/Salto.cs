using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class Salto : MonoBehaviour
{

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private bool grounded = false;

    void Start()
    {
    }
    void Update()
    {
    }

    private void FixedUpdate()
    {
        if (grounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;

            if (Input.GetButton("Jump")) moveDirection.y = jumpSpeed;
        }

        CharacterController controller = (CharacterController)GetComponent(typeof(CharacterController));
       // CollisionFlags = controller.Move(moveDirection * Time.deltaTime);
       // grounded = (flags CollisionFlags.CollidedBelow) != 0;

    }
}

/*void jump()
{
    Vector3 Motion;
    Motion = Vector3.zero;
    CharacterController controller;
    controller = gameObject.GetComponent<CharacterController>();
    //jump
    if (Input.GetKey(KeyCode.Space) || controller.isGrounded)
    {
        Motion.y = jumpForce;
    }

    Motion.y -= gravity * Time.deltaTime;
    controller.Move(Motion * Time.deltaTime);
}*/
