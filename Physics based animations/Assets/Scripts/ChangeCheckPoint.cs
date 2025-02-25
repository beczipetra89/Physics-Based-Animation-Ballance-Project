﻿//Change check point by destroying the previous Death Zone

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChangeCheckPoint : MonoBehaviour
{
    public GameObject destroyPreviousZone;
    public GameObject deactivatedPreviousArea;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(destroyPreviousZone);
            Destroy(gameObject);
        deactivatedPreviousArea.SetActive(false);
    }
}
