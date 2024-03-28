using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Playermovement : MonoBehaviour
{
    private CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f * 2;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    Vector3 velocity;

    bool isGrounded;
    bool isMoving;

    private Vector3 lastPosition = new Vector3(0f, 0f, 0f); 
    // Start is called before the first frame update
    public void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //grounded check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        //resseting the default velocity
        if(isGrounded && velocity.y < 0f )
        {
            velocity.y = -2f;

        }

        // getting the inputs
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        //creating the moving vector
        Vector3 move = transform.right * x + transform.forward * z;
        //actually moving the player
        controller.Move(move * speed * Time.deltaTime);
        //check if the player can jump
        if (Input.GetButtonDown("Jump") && isGrounded )
        {
            //Atually jumping
            velocity.y = Mathf.Sqrt(jumpHeight * 2f * gravity);
        }

        //falling down
        velocity.y += gravity * Time.deltaTime;
        //executing the jump

        if (lastPosition != gameObject.transform.position && isGrounded == true)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;

        }
        lastPosition = gameObject.transform.position;
    }
}
