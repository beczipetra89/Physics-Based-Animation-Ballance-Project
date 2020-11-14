// WOODEN BALL: medium weight, bounces back 

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WoodBallController : MonoBehaviour
{
    public Rigidbody body;
    public float woodBallSpeed;
    public float jumpForce;
    public bool isGrounded = true;
    public bool isHeated = false;
  
    public Material mat;
    public GameObject fire;

    public HealthManager healthManager;

    private void start()
    {
        body = GetComponent<Rigidbody>();

        Renderer renderer = GetComponent<Renderer>();
        mat = renderer.material;
    }
    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal") * Time.deltaTime * woodBallSpeed;
        float moveVertical = Input.GetAxis("Vertical") * Time.deltaTime * woodBallSpeed;

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        body.AddForce(movement, ForceMode.Impulse);
        // Roll object
        //Rotaiton along x-axis
        body.AddTorque(new Vector3(moveHorizontal, 0, moveVertical) * woodBallSpeed * Time.deltaTime); // *delta time: stabelize movement (balance the speed) regardless the number of frames per seconds, support old computers

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            body.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse); // Insatnt force impulse to the gameobjects ridiidboy using its mass
            isGrounded = false;
        }

        if (!isGrounded)
        {
            Physics.gravity = new Vector3(0, -50.0F, 0);
        }

        if (!isHeated)
        {
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_Color", Color.grey);
            fire.SetActive(false);
        }

        if (isHeated)
        {
            mat.SetColor("_Color", Color.black);
            mat.DisableKeyword("_EMISSION");
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
        if (other.gameObject.tag == "Hot")
        {
            isHeated = true;
        }

        if (other.gameObject.tag == "DeathZone")
        {
            healthManager.health -= 1;
        }

    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hot")
        {
            isHeated = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hot")
        {
            isHeated = false;
        }
    }
}
