using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicMovement : MonoBehaviour
{
    public CharacterController controlls;
    //i am calling an already existing component"Character controller"

    public float speed = 12f;

    public float gravity = -9.81f;
    //earth gravity 0_o

    public float jumpH = 5f;

    

    Vector3 velocity;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       

        // we are gonna use the axis for movement obv x&z because we dont want to go up
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        //this way the movement will be transformed depending where does our player "look"
        if (controlls.isGrounded)
        {
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpH * -2f * gravity); //gotta love maths 
            }
        }

        controlls.Move(move * speed * Time.deltaTime);
        //the move in the brackets is the Vector3 from above, the speed variable, and the time delta time so that the movement wont be affected by frames

        velocity.y += gravity * Time.deltaTime;

        controlls.Move(velocity * Time.deltaTime);
    }
}
