// PAPER BALL: lightweight, controllable meanwhile in air, gets on fire (particle system )when heated up

using UnityEngine;
using System;
using System.Collections;

public class FoamBallController : MonoBehaviour
{
    public Rigidbody body;
    public bool isGrounded = true;
    public float speed;
    public float jumpForce;
    public bool isHeated = false;
    
    public GameObject fire; // fire particle system
    public GameManager gameManager;


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
            Physics.gravity = new Vector3(0, -40.0F, 0);
        }


        if (!isHeated)
        {
            fire.SetActive(false);
        }

        if (isHeated)
        {
            fire.SetActive(true);
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
   
        if (other.gameObject.tag == "DeathZone" )
        {
            gameManager.health -= 1;
        }

        if (other.gameObject.tag == "Hot")
        {
            isHeated = true;
            StartCoroutine(Delay());
            gameManager.health -= 1;
        }

    }


    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hot")
        {
            isHeated = false;
        }

    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(2);
    }


}