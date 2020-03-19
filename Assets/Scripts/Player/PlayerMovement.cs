using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[AddComponentMenu("Game Systems/RPG/Player/Mouselook")]

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    public stats.BaseStats playerStats;
    [Header("Physics")]
    public CharacterController controller;
    public float gravity = 20f;
    [Header("Movement Variables")]
    public float moveSpeed;
    public float walkSpeed, jumpSpeed, superJump, sprintSpeed, superSprintSpeed, crouchSpeed;
    [Header("Sprinting and Crouching")]
    public bool isSprinting;
    public bool stamRegen;
    public float stamDelay;
    bool LastUsedSprint = false;
    bool toggleSprint = false;

    private Vector3 _moveDir;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (!stamRegen)
        {
            stamDelay += Time.deltaTime;
            if (stamDelay >= 5)
            {
                stamRegen = true;
            }
        }
        Move();
    }
    void FixedUpdate()
    {

        if (isSprinting == true)
        {
            StaminaDrain(10);
        }

    }
    private void LateUpdate()
    {
        if (!isSprinting && playerStats.characterResources[1].curValue < playerStats.characterResources[1].maxValue && stamRegen)
        {
            StaminaRegen();
        }
    }

    void Move()
    {
        if (controller.isGrounded && !stats.BaseStats.isDead)
        {

            moveSpeed = walkSpeed;

            isSprinting = false;


            //if (Input.GetButtonDown("Sprint"))
            //{
            //    toggleSprint = !toggleSprint;
            //}
            //if(toggleSprint)
            //{
            //    Sprint();
            //}


            bool sprint = Input.GetButton("Sprint");
            bool crouch = Input.GetButton("Crouch");

            if (sprint && !crouch && playerStats.characterResources[1].curValue > 0)
            {
                Sprint();
                LastUsedSprint = true;
            }
            else if (!sprint && crouch)
            {
                Crouch();

                LastUsedSprint = false;
            }
            else if (sprint && crouch)
            {
                if (LastUsedSprint)
                {
                    Crouch();
                }
                else
                {
                    Sprint();
                }
            }


#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.P))
            {
                moveSpeed = superSprintSpeed;
            }

#endif
            _moveDir = transform.TransformDirection(new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")) * moveSpeed);// * Time.deltaTime);

            if (Input.GetButton("Jump"))
            {
                _moveDir.y = jumpSpeed;
            }
#if UNITY_EDITOR
            if (Input.GetKey(KeyCode.L))
            {
                _moveDir.y = superJump;
            }
#endif
        }
        _moveDir.y -= gravity * Time.deltaTime;
        controller.Move(_moveDir * Time.deltaTime);
    }

    public void StaminaDrain(float stam)
    {
        playerStats.characterResources[1].curValue -= stam * Time.deltaTime;
        stamRegen = false;
        stamDelay = 0;
    }
    public void StaminaRegen()
    {
        playerStats.characterResources[1].curValue += Time.deltaTime * (playerStats.characterResources[1].regenValue);

    }

    void Crouch()
    {
        moveSpeed = crouchSpeed;

    }

    void Sprint()
    {
        moveSpeed = sprintSpeed;
        if (moveSpeed == sprintSpeed)
        {
            isSprinting = true;
        }
    }
}