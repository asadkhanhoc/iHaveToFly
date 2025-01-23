using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(1, 12)]
    [SerializeField] private float lifeTime = 12f;

    public float minSpeed;
    public float maxSpeed;

    float speedIncreaseRate = 0.5f; // Adjust this value for how quickly speed increases

    float speed;

    Player playerScript;

    public int damage;

    private bool isPaused = false; // Track if the enemy is paused

    // Use this for initialization
    void Start()
    {
        speed = Random.Range(minSpeed, maxSpeed);
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

        Destroy(gameObject, lifeTime);
    }

    // Update is called once per frame
    void Update()
    {

        if (!isPaused)
        {
            // Gradually increase the speed over time
            speed += speedIncreaseRate * Time.deltaTime;

            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
    }

    // Method to pause or resume the enemy
    public void TogglePause(bool pause)
    {
        isPaused = pause;
    }

    private void OnTriggerEnter2D(Collider2D hitObject)
    {
        if (hitObject.tag == "Player")
        {
            playerScript.TakeDamage(damage);
            //playerScript.DecrementScore();
            Destroy(gameObject);
        }

        if (hitObject.tag == "Bullet")
        {
            playerScript.IncrementScore();
            Destroy(gameObject);
            Destroy(hitObject.gameObject);
        }
    }
}
