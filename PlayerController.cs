using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 8.0f;
    private float rot = 0.0f;
    private float walkSpeed = 8.0f;
    private float runSpeed = 12.0f;
    //private float jumpSpeed = 10.0f; moveDirection.y = jumpspeed
    private float gravity = 20.0f;
    private float rotateSpeed = 1.3f;
    private Vector3 moveDirection = Vector3.zero;
    private bool isWalking = true;
    private Animator animator;
    CharacterController controller;


    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {

        if (controller.isGrounded) // if standing
        {   
            if (Input.GetKeyDown(KeyCode.LeftShift)) { // toggle run & walk
                if (isWalking) {
                    speed = runSpeed;
                    isWalking = false;
                } 
                else {
                    speed = walkSpeed;
                    isWalking = true;
                }
            }

            if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow)) {
                if (isWalking) {
                    animator.SetInteger("con", 1);
                }
                else if (!isWalking) {
                    animator.SetInteger("con", 2);
                }
                moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
                moveDirection = transform.TransformDirection(moveDirection);
                moveDirection *= speed;
            }
            
            if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) {
                animator.SetInteger("con", 0);
                moveDirection = Vector3.zero;
            }
        }
        //Rotate Player
        rot += Input.GetAxis("Horizontal") * rotateSpeed;
        transform.eulerAngles = new Vector3(0, rot, 0); //walk from the rotated direciton

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}

