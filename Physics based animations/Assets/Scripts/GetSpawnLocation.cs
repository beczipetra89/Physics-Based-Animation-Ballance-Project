//Assign spawn point where to spawn the player
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//CheckPoint

public class GetSpawnLocation : MonoBehaviour
{
    public Transform spawnPoint;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.position = spawnPoint.transform.position;
            other.attachedRigidbody.velocity = Vector3.zero;
            other.attachedRigidbody.angularVelocity = Vector3.zero;
        }
    }
}
