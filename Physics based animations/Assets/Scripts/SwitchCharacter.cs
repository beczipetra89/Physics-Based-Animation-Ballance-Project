using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{
    public GameObject[] balls = new GameObject[4];

    int currentActive;

    void Start()
    {
        currentActive = 0;
        balls[currentActive].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            balls[currentActive].SetActive(false);
            currentActive++;
            if (currentActive == 4) currentActive = 0;
            balls[currentActive].SetActive(true);
        }
    }
}
