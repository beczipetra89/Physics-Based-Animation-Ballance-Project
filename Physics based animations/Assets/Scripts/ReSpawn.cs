// RESPAWN PLAYER TO SPAWN POINT IF FALLEN DOWN (COLLIDED WITH THIS OBJECT)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawn : MonoBehaviour
{
    //[SerializeField] private Transform respawnPoint;
    
    [SerializeField] private Transform respawnPoint;

   void OnTriggerEnter(Collider player)
    {
        //player.transform.position = respawnPoint.transform.position;
        player.transform.position = respawnPoint.transform.position;
    }
}
