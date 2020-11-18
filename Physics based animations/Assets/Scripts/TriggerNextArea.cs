using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextArea : MonoBehaviour
{
    //public GameObject currentArea;
    public GameObject nextArea;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            nextArea.SetActive(true);
        }

    }
}
