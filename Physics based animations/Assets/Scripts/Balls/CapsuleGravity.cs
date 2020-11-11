// Invokes the Attract() method from FauxGravity, this rigidbody will be pulled towards the object

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleGravity : MonoBehaviour
{

    public FauxGravity gravitypull;
    private Transform myTransform; 

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        GetComponent<Rigidbody>().useGravity = false;
        myTransform = transform;

    }

    // Update is called once per frame
    void Update()
    {
        gravitypull.Attract(myTransform);
      
    }
}
