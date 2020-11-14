// Elevate and hover a game object upon entering this trigger zone

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverTrigger : MonoBehaviour
{
    public float windForce = 100f; //1000f
   

    void OnTriggerEnter(Collider other)
    {
        other.attachedRigidbody.AddForce(Vector3.up * windForce, ForceMode.Force);
        other.attachedRigidbody.constraints = RigidbodyConstraints.FreezePositionY;
    }

    void OnTriggerStay(Collider other)
    {
        other.attachedRigidbody.constraints = RigidbodyConstraints.FreezePositionX;
        other.attachedRigidbody.constraints = RigidbodyConstraints.FreezePositionZ;

        
}

    void OnTriggerExit(Collider other)
    {
        other.attachedRigidbody.constraints = RigidbodyConstraints.None;
    }
}
