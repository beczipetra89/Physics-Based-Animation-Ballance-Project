// JELLY BALL: has soft body, deformable, springy and gluey (attracted by the Gravity Island)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyBallController : MonoBehaviour
{

    public Rigidbody body;
    public FauxGravity gravitypull;
    private Transform myTransform;

    private Vector3 moveDirection;

    public float jellyBallSpeed;
    public float jumpForce;
    public float moveSpeed = 15f;

    public bool inFauxGravity = false;
    public bool isJumping = false;
    public bool isGrounded = true;
    public bool isHeated = false;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        inFauxGravity = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        ////////////////// MOVE ON THE GROUND NORMALLY ////////////////////
        if (!inFauxGravity)
        {
            float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * jellyBallSpeed;
            float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * jellyBallSpeed;

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            body.AddForce(movement, ForceMode.Impulse);
            // Roll object
            //Rotaiton along x-axis
            body.AddTorque(new Vector3(moveHorizontal, 0, moveVertical) * jellyBallSpeed * Time.deltaTime); // *delta time: stabelize movement (balance the speed) regardless the number of frames per seconds, support old computers

            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                body.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // Insatnt force impulse to the gameobjects ridiidboy using its mass
                isGrounded = false;
                isJumping = true;
            }

            if (!isGrounded)
            {
                Physics.gravity = new Vector3(0, -50.0F, 0);
            }
        }


        ////////////////// MOVE WHILE STICKED TO THE GRAVITY ISLAND (ball with gravity pull) ////////////////////

        if (inFauxGravity)
        {

            gravitypull.Attract(myTransform);

            // set the move direction in a new vector
            moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;
            // use local space instead of world space to the rigidbody can follow the curve
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);

            if (Input.GetButtonDown("Jump"))
            {
                body.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // Insatnt force impulse to the gameobjects ridiidboy using its mass
                isJumping = true;
                inFauxGravity = false;
                GetComponent<Rigidbody>().useGravity = true;
            }

        }


        if (!isHeated)
        {
          //
        }

        if (isHeated)
        {
          //
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "GravityIsland")
        {
            isGrounded = false;
            inFauxGravity = true;

            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            GetComponent<Rigidbody>().useGravity = false;
            myTransform = transform;
        }

        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            isJumping = false;
            inFauxGravity = false;
            GetComponent<Rigidbody>().useGravity = true;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hot")
        {
            isHeated = true;
         
        }

    }

    void OnTriggerStay(Collider other)
    {
        isHeated = true;
  
    }

    void OnTriggerExit(Collider other)
    {
        isHeated = false;
    }
}
