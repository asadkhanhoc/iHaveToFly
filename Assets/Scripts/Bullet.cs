using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bullet : MonoBehaviour
{
  
   
    [Range(1, 40)]
    [SerializeField] private float speed = 10f;

    [Range(0.1f, 1)]
    [SerializeField] private float lifeTime = 0.73f;

    private Rigidbody2D rb;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, lifeTime);

    }

    private void FixedUpdate()
    {
        rb.velocity = transform.up * speed;
    }

}
