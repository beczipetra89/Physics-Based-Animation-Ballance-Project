// Create gravitational pull "Attract()" force for a rigidbody  

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravity : MonoBehaviour
{
    public float gravity = -50f; //-10f

    public void Attract(Transform body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        Vector3 bodyUp = body.up;  //always face the body to gravity up

        // Add force to the body's rigidbody to be pulled towards the center of planet 
        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        // Rotation: between 2 directions, the gravityUp and the bodyUp also by adding the body's current rotation
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;

        //Move towards the target rotation smoothly using Slerp and some speed value 
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.deltaTime);
    }
    
}
