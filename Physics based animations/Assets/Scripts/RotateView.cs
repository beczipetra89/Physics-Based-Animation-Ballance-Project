// Rotate the world under the player left and right (Q and E), must use occludee static on the world elements otherwise they will always be rendered, even outside of the camera

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateView : MonoBehaviour
{

    void Update()
    {
        // ROTATE LEFT
        if(Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Rotate(Vector3.up, 90, 1.0f) ); 
        }
       
        // ROTATE RIGHT
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(Rotate(Vector3.up, -90, 1.0f));
        }
    }
 
   IEnumerator Rotate(Vector3 axis, float angle, float duration = 1.0f)
   {
        Quaternion from = transform.rotation;
        Quaternion to = transform.rotation;
        to *= Quaternion.Euler(axis * angle);

        float elapsed = 0.0f;
        while (elapsed < duration)
        {
            transform.rotation = Quaternion.Slerp(from, to, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
         } 
       
        transform.rotation = to;
    }

}
