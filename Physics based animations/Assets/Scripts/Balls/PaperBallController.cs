// PAPER BALL: lightweight, controllable meanwhile in air, gets on fire (particle system )when heated up

using UnityEngine;
using System;

public class PaperBallController : MonoBehaviour
{

    public Rigidbody body;
    public bool isGrounded = true;
    public float speed;
    public float jumpForce;
    public bool isHeated = false;
    float baseIntensity = 0f;
    float targetIntensity = 10f;

    public Material mat;

    private void start()
    {
        body = GetComponent<Rigidbody>();

        Renderer renderer = GetComponent<Renderer>();
        mat = renderer.material;
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


        if (!isHeated)
        {
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_Color", Color.white);
        }

        if (isHeated)
        {
            mat.SetColor("_Color", Color.black);
            mat.DisableKeyword("_EMISSION"); 
        }

    }




    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
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