// RESPAWN PLAYER TO SPAWN POINT IF FALLEN DOWN (COLLIDED WITH THIS OBJECT)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    //[SerializeField] private Transform respawnPoint;
    
    [SerializeField] public Transform respawnPoint;

   void OnTriggerEnter(Collider other)
    {
        other.transform.position = respawnPoint.transform.position;
        other.attachedRigidbody.velocity = Vector3.zero;
        other.attachedRigidbody.angularVelocity = Vector3.zero;
    }
}
