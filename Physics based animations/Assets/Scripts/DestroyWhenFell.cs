using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWhenFell : MonoBehaviour
{
    public GameObject go;

    void Update()
    {
        if(transform.position.y < -100)
        {
            Destroy(go);
        }

    }
}
