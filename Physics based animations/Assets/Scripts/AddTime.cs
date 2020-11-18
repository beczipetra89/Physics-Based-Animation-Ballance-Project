using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddTime : MonoBehaviour
{
    public GameObject destroy_this;
    public GameManager gameManager;
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            gameManager.timeRemaining += 30;
            Destroy(destroy_this);
        }

    }
}
