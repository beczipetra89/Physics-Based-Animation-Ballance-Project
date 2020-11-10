// PAPER BALL: lightweight, controllable meanwhile in air

using UnityEngine;
using System;

public class PaperBallController : MonoBehaviour
{

    public Rigidbody body;
    public bool isGrounded = true;
    public float speed;
    public float jumpForce;

    private void start()
    {
        body = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);


        body.AddForce(movement * speed);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            body.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // Insatnt force impulse to the gameobjects rididboy using its mass
            isGrounded = false;
        }

        if (!isGrounded)
        {
            Physics.gravity = new Vector3(0, -20.0F, 0);
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

}