//STONE BALL: heavy weight, can push heavy objects and glows (material emission and color)red when gets heated up

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBallController : MonoBehaviour
{

    public Rigidbody body;
    public float stoneBallSpeed;
    public float jumpForce;
    public bool isGrounded = true;
    public bool isHeated = false;
    float baseIntensity = -10f;
    float targetIntensity = 10f;

    public Material mat;
    public GameManager gameManager;

    private void start()
    {
       body = GetComponent<Rigidbody>();
       
        Renderer renderer = GetComponent<Renderer>();
        mat = renderer.material; 


    }
    // Update is called once per frame
    void FixedUpdate()
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

        // Change emission color - intensity when it gets hot

        if (!isHeated)
        {
            mat.DisableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", Color.black * baseIntensity);
        }

        if (isHeated)
        {
            mat.EnableKeyword("_EMISSION");
            mat.SetColor("_EmissionColor", Color.red * targetIntensity);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
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
            gameManager.health -= 1;
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
