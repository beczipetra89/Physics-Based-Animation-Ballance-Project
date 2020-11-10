using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnByRange : MonoBehaviour
{
    public GameObject triggering;

 
    void Start()
    {
        triggering.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider _col)
    {
        if (_col.gameObject.CompareTag("Player"))
        {
            triggering.SetActive(true);
        }
    }

    void OnTriggerExit(Collider _col)
    {
        if (_col.gameObject.CompareTag("Player"))
        {
            triggering.SetActive(false);
        }
    }
}
