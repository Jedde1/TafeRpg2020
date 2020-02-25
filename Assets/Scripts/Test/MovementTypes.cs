using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTypes : MonoBehaviour
{
    public int speed;
    public int walkSpeed;
    [Header("Types of Movement")]
    public bool pos;
    public bool translate, addForce, velocity, charController;

    [Header("Reference Variables")]
    public Rigidbody rb;
    public CharacterController charC;
    void Update()
    {
        /*
         Bool is True or False
         Variable of Bools default start false

        in an if statement these are ways you can ask if
        True
        if(pos)
        if(pos == true)

        False
        if(!pos)
        if(pos == false)
         */
        if (pos)
        {
            //Move position forward on Z by speed
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        if (translate)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        if (addForce)
        {
            rb.AddForce(transform.forward * speed * Time.deltaTime);
        }
        if (velocity)
        {
            rb.velocity = transform.forward * speed * Time.deltaTime;
        }
        if (charController)
        {
            if (Input.GetButton("Horizontal"))
            {
                speed = walkSpeed;
            }
        }
    }
}
