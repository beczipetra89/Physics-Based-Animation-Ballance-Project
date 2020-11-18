using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollSkyBox : MonoBehaviour
{
    //public float rotateSpeed = 1.2f;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Skybox>().material.SetFloat("_Rotation", Time.time * 1.23f);
    }
}
