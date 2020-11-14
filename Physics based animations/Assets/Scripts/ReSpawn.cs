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
        //player.transform.position = respawnPoint.transform.position;
        other.transform.position = respawnPoint.transform.position;
    }
}
