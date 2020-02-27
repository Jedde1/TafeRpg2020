using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Game Systems/RPG/Player/Mouselook")]

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    [Header("Phisics")]
    public CharacterController controller;
    public float gravity = 20f;
    [Header("Movement Variables")]
    public float moveSpeed;
    public float walkSpeed, jumpSpeed, superJump, sprintSpeed, superSprintSpeed, crouchSpeed;

    private Vector3 _moveDir;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        
    }
  
    void Move()
    {
        if (controller.isGrounded)
        {
            _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed);
            moveSpeed = walkSpeed;
            if (Input.GetButton("Jump"))
            {
                _moveDir.y = jumpSpeed;
            }
            else if (Input.GetKey(KeyCode.L))
            {
                _moveDir.y = superJump;
            }
            else if (Input.GetButton("Sprint"))
            {
                moveSpeed = sprintSpeed;
                Debug.Log("Move");
            }
            else if (Input.GetKey(KeyCode.P))
            {
                moveSpeed = superSprintSpeed;
            }
            else if (Input.GetButton("Crouch"))
            {
                moveSpeed = crouchSpeed;                
            }
        }
        _moveDir.y -= gravity * Time.deltaTime;
        controller.Move(_moveDir * Time.deltaTime);
        
    }
}





/*
  private void Move()
  {
      moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * walkSpeed);

      moveDir = gravity * Time.deltaTime;
      controller.Move(moveDir * Time.deltaTime);
  }
  */
