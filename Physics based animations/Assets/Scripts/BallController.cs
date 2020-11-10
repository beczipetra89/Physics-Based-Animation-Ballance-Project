using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballSpeed;


    // Update is called once per frame
    void Update()
    {
        float xSpeed = Input.GetAxis("Horizontal");
        float ySpeed = Input.GetAxis("Vertical");
       
        Rigidbody body = GetComponent<Rigidbody>();
        
        // Roll object
        //Rotaiton along x-axis
        body.AddTorque(new Vector3(xSpeed, 0, ySpeed) * ballSpeed * Time.deltaTime); // *delta time: stabelize movement (balance the speed) regardless the number of frames per seconds, support old computers
    }
}
