using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollorBall : MonoBehaviour
{


      public GameObject target;
      public float xOffset, yOffset, zOffset;

      // Update is called once per frame
      void Update()
      {
          transform.position = target.transform.position + new Vector3(xOffset, yOffset, zOffset); // camera's position to the target's position but adding some distance
          transform.LookAt(target.transform.position);
      }
     

} 
