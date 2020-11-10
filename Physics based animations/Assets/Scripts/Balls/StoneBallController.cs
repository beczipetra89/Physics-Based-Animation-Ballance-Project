using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBallController : MonoBehaviour
{

    public Rigidbody body;
    public float stoneBallSpeed;
    public float jumpForce;
    public bool isGrounded = true;

    private void start()
    {
       body = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * stoneBallSpeed;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * stoneBallSpeed;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        body.AddForce(movement, ForceMode.Impulse);
        // Roll object
        //Rotaiton along x-axis
        body.AddTorque(new Vector3(moveHorizontal, 0, moveVertical) * stoneBallSpeed * Time.deltaTime); // *delta time: stabelize movement (balance the speed) regardless the number of frames per seconds, support old computers

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            body.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // Insatnt force impulse to the gameobjects ridiidboy using its mass
            isGrounded = false;
        }

        if (!isGrounded)
        {
            Physics.gravity = new Vector3(0, -50.0F, 0);
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
