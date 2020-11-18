using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBg : MonoBehaviour
{

    public float speed;
    Renderer _renderer;

    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 offset = new Vector2(0, Time.time * speed);
        _renderer.material.mainTextureOffset = offset;
    }
}
