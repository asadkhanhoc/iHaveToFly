using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [SerializeField] float moveSpeed = -10f;

    float singleTextureWidth;


    [SerializeField] GameObject player; // Reference to the player GameObject

    // Start is called before the first frame update
    void Start()
    {
        SetupTexture();
        
    }

    private void SetupTexture()
    {
        Sprite sprite = GetComponent<SpriteRenderer>().sprite;
        singleTextureWidth = sprite.texture.width / sprite.pixelsPerUnit;
    }

    void Scroll()
    {
        float delta = moveSpeed * Time.deltaTime;
        transform.position += new Vector3(delta, 0f, 0f);
    }

    void CheckReset()
    {
        if((Mathf.Abs(transform.position.x) - singleTextureWidth) > 0)
        {
            transform.position = new Vector3(0.0f, transform.position.y, transform.position.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player exists
        if (player != null)
        {
            Scroll();
            CheckReset();
        }
    }
}
