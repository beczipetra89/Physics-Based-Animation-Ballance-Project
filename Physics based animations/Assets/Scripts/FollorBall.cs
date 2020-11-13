//SWITCH PLAYERS WITH "ENTER" KEY AND CAMERA FOLLOWS THE PLAYER

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollorBall : MonoBehaviour
{
    [Header("Players List")]
    public GameObject[] balls = new GameObject[4];
    int currentActive;
    private Vector3 savedPosition;  // Ball's position
    [Header("Camera Offset")]
    public float xOffset;
    public float yOffset;
    public float zOffset; 
   

    void Start()
    {
        currentActive = 0;
        balls[currentActive].SetActive(true);
        transform.position = balls[currentActive].transform.position + new Vector3(xOffset, yOffset, zOffset);
    }

    void Update()
    {
        transform.position = balls[currentActive].transform.position + new Vector3(xOffset, yOffset, zOffset);
        transform.LookAt(balls[currentActive].transform.position);


        //Switch players
        if (Input.GetKeyDown(KeyCode.Return))
        {
            savedPosition = balls[currentActive].transform.position;
            Vector3 previousCamPos = transform.position;
           
            // Deactivate the current ball and set the next one active
            balls[currentActive].SetActive(false);
            currentActive++;
            if (currentActive == 4) currentActive = 0;
            balls[currentActive].SetActive(true);

            // Set the current ball's position to the previous ball's position that was just deactivated
            balls[currentActive].transform.position = savedPosition;
        }
    }
}
