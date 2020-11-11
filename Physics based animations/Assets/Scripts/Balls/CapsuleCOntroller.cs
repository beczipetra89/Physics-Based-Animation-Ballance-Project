
//  Test controller for the test object (capsule)
// Update the rigidbody's rotation

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleCOntroller : MonoBehaviour
{
    public float moveSpeed = 15f;
    private Vector3 moveDirection;

    // Update is called once per frame
    void Update()
    {
        // set the move direction in a new vector
        moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical")).normalized;  
    }

    void FixedUpdate()
    {
        // use local space instead of world space to the rigidbody can follow the curve
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + transform.TransformDirection(moveDirection) * moveSpeed * Time.deltaTime);
    }
}
