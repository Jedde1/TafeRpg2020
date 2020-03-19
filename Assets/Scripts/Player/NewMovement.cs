using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Game Systems/RPG/Player/Mouselook")]

[RequireComponent(typeof(CharacterController))]

public class NewMovement : MonoBehaviour
{
    #region Variables
    public stats.BaseStats playerStats;
    [Header("Physics")]
    public CharacterController controller;
    public float gravity = 20f;
    [Header("Movement Variables")]
    public float moveSpeed;
    public float walkSpeed, jumpSpeed, superJump, sprintSpeed, superSprintSpeed, crouchSpeed;
    [Header("KeyCodes")]
    public KeyCode Forward;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Backward;
    public KeyCode Jump;
    public KeyCode Sprint;
    public KeyCode Crouch;
    public float directionValue;

    private Vector3 _moveDir;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();

        Forward = KeyBindManager.keys["Forward"];
        Left = KeyBindManager.keys["Left"];
        Right = KeyBindManager.keys["Right"];
        Backward = KeyBindManager.keys["Backward"];
        Jump = KeyBindManager.keys["Jump"];
        Sprint = KeyBindManager.keys["Sprint"];
        Crouch = KeyBindManager.keys["Crouch"];
    }

    private void Update()
    {
        Move();
    }
    void Move()
    {
        if (controller.isGrounded && !stats.BaseStats.isDead)
        {
            moveSpeed = walkSpeed;
            if (Input.GetKey(Forward))
            {
                _moveDir.z = 1;
            }
            if (Input.GetKey(Backward))
            {
                _moveDir.z = -1;
            }
            if (Input.GetKey(Left))
            {
                _moveDir.x = -1;
            }
            if (Input.GetKey(Right))
            {
                _moveDir.x = 1;
            }
            if (Input.GetKey(Jump))
            {
                _moveDir.y = 1;
                moveSpeed = jumpSpeed;
            }
            if (Input.GetKey(Sprint))
            {

                moveSpeed = sprintSpeed;
            }
            if (Input.GetKey(Crouch))
            {

                moveSpeed = crouchSpeed;
            }
            
        }
        _moveDir.y -= gravity * Time.deltaTime;
        controller.Move(_moveDir * Time.deltaTime);
    }
}




