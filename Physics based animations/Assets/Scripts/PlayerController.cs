using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator animator;

    public float speed;
    public float strafeSpeed; // Left and right speed
    public float jumpForce;

    public Rigidbody hips;
    public bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        hips = GetComponent<Rigidbody>();
    }

    private void FixedUpdate() // fixedUpdate should be used if plazing with physics and forces
    {

        // WALK & RUN
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // RUN
            if (Input.GetKey(KeyCode.LeftShift))
            {
                animator.SetBool("isWalking", true);
                animator.SetBool("isRunning", true);

                hips.AddForce(hips.transform.forward * speed * 1.5f);
            }
            else
            {
             //WALK
             animator.SetBool("isWalking", true);
                // hips.AddForce(hips.transform.forward * speed);
                hips.AddForce(-hips.transform.forward * speed);   // even if looking to the left, the forward vector will be the same
            }
        }
        else
        {
            //If not holding any key
            animator.SetBool("isWalking", false);
            animator.SetBool("isRunning", false);
            animator.SetBool("isSideWalking", false);
            animator.SetBool("isWalkingBackwards", false);
            animator.SetBool("isJumping", false);
        }
        // LEFT
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            animator.SetBool("isSideWalking", true);
            //hips.AddForce(-hips.transform.right * strafeSpeed);
            hips.AddForce(hips.transform.right * strafeSpeed);
        }

        // BACKWARDS
        if (Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("isWalkingBackwards", true);
            //hips.AddForce(-hips.transform.forward * speed);
            hips.AddForce(hips.transform.forward * speed);
        }

        // RIGHT
        if (Input.GetKey(KeyCode.RightArrow))
        {
            animator.SetBool("isSideWalking", true);
            //hips.AddForce(hips.transform.right * strafeSpeed);
            hips.AddForce(-hips.transform.right * strafeSpeed);
        }

        // JUMP
        if (Input.GetAxis("Jump") > 0)  // more precision than KeyCode if we have a joystick
        {
            if (isGrounded)
            {
                animator.SetBool("isJumping", true);
                hips.AddForce(new Vector3(0, jumpForce, 0)); //Vector3 (X,Y,Z)
                isGrounded = false;
            }
        }
    }
}
