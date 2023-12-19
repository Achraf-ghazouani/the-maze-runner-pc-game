using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 5f;
    public float runSpeed = 2f; // Increased speed for running
    public float gravity = 20f;
    public float rotSpeed = 80f;
    Animator anim;

    CharacterController controller;
    Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Set walking animation
        if (Input.GetKey(KeyCode.W))
        {
            anim.SetBool("IsWalking", true);
        }
        else
        {
            anim.SetBool("IsWalking", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            anim.SetBool("walkForword", true);
        }
        else
        {
            anim.SetBool("walkForword", false);
        }

        // Set running animation and adjust speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            anim.SetBool("IsRunning", true);
            SetSpeed(runSpeed);
        }
        else
        {
            anim.SetBool("IsRunning", false);
            SetSpeed(walkSpeed);
        }

        // Rotation
        if (horizontal != 0f)
        {
            transform.Rotate(Vector3.up * horizontal * rotSpeed * Time.deltaTime);
        }

        moveDirection = new Vector3(0, 0, vertical);
        moveDirection *= walkSpeed; // Default to walk speed

        // If running, adjust speed
        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveDirection *= runSpeed;
        }

        moveDirection = transform.TransformDirection(moveDirection);

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    // Helper function to set the player's speed
    void SetSpeed(float speed)
    {
        controller.Move(moveDirection * speed * Time.deltaTime);
    }
}
