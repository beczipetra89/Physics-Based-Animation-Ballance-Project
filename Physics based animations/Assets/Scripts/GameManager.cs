using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Health & Lives")]
    public int health;
    public int numberOfLifeIcons;

    public Image[] ballIcons;
    public Sprite fullBall;
    public Sprite emptyBall;

    [Header("Timer")]
    public float timeRemaining = 120;
    public bool timerIsRunning = false;
    public Text timerText;

    private void Start()
    {
        timerIsRunning = true; // start the timer
    }

    void Update()
    {

        // Change a life sprite if a life is reduced
        if (health > numberOfLifeIcons)
        {
            health = numberOfLifeIcons;
        }

        if (health < 0)
        {
            timerIsRunning = false;
            Die(); // Die of no life left
        }

            for (int i = 0; i < ballIcons.Length; i++)
        {
            if (i < health)
            {
                ballIcons[i].sprite = fullBall;
            }
            else
            {
                ballIcons[i].sprite = emptyBall;
            }

            if (i < numberOfLifeIcons)
            {
                ballIcons[i].enabled = true;
            }
            else
            {
                ballIcons[i].enabled = false;
            }
        }

        // Game Timer
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                Debug.Log("Time has run out!");
                timeRemaining = 0;
                timerIsRunning = false;
                Die();
            }
        }
    }
    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void Die()
    {
        SceneManager.LoadScene("Start scene");
    }

    
}

