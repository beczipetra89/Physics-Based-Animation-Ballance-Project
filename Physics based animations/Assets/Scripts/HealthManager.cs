using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    public int health;
    public int numberOfLifeIcons;

    public Image[] ballIcons;
    public Sprite fullBall;
    public Sprite emptyBall;


    void Update()
    {
        if (health > numberOfLifeIcons)
        {
            health = numberOfLifeIcons;
        }

        if (health < 0)
        {
            Die();
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
    }

    public void Die()
    {
        SceneManager.LoadScene("Start scene");
    }

}

