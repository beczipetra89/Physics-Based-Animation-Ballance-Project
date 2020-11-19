using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ReachEnd : MonoBehaviour
{
    public GameObject particles;
    public bool isAtTheEnd = false; 

 
    void Update()
    {
        if (isAtTheEnd)
        {
            particles.SetActive(true);
            StartCoroutine(LoadEndScene());
        }
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            isAtTheEnd = true;
        }
    }

    IEnumerator LoadEndScene()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("End Scene");

    }

}
