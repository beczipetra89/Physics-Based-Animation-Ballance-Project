using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBezierCurve : MonoBehaviour
{

    [SerializeField]
    private Transform[] points;
    private int pointToGo;
    private float tParam;
    private Vector2 playerPosition;
    private float speedModifier;
    private bool coroutineAllowed;


    public bool isWindy;

    // Start is called before the first frame update
    void Start()
    {
        pointToGo = 0;
        tParam = 0f;
        speedModifier = 0.5f;
        coroutineAllowed = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isWindy) {

            if (coroutineAllowed)
            {
                StartCoroutine(GoByRoute(pointToGo));
            }

        }
    }

    private IEnumerator GoByRoute(int pointNumber)
    {
        coroutineAllowed = false;

          Vector2 p0 = points[pointNumber].GetChild(0).position;
          Vector2 p1 = points[pointNumber].GetChild(1).position;
          Vector2 p2 = points[pointNumber].GetChild(2).position;
          Vector2 p3 = points[pointNumber].GetChild(3).position; 

        while (tParam < 1)
        {
            tParam += Time.deltaTime * speedModifier;

            playerPosition = Mathf.Pow(1 - tParam, 3) * p0 +
                3 * Mathf.Pow(1 - tParam, 2) * tParam * p1 +
                3 * (1 - tParam) * Mathf.Pow(tParam, 2) * p2 +
                Mathf.Pow(tParam, 3) * p3;
            
            transform.position = playerPosition;
            yield return new WaitForEndOfFrame();
        }

        tParam = 0f;
        pointToGo += 1;

        if (pointToGo > points.Length - 1)
            pointToGo = 0;

        coroutineAllowed = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "FanBezierCurve")
        {
            isWindy = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {

    }

}
