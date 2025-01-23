using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{  // Score variables
    private int score = 0; // Add score variable
    public TMP_Text scoreDisplay; // Reference to score text UI

    private int health = 10;
    public TMP_Text healthDisplay;

    public GameObject losePanel;
    public TMP_Text loseText;

    Rigidbody2D rb;

    public GameObject enemySpawner; // Reference to the GameObject with the spawning script

    public AudioSource birdSound;

    // Start is called before the first frame update
    void Start()
    {
        // Play the fire sound
        if (birdSound != null)
        {
            birdSound.PlayDelayed(0.1f); // Plays the bird sound on game start
        }

        scoreDisplay.text = "Score: " + score; // Initialize score display
        rb = GetComponent<Rigidbody2D>();
        healthDisplay.text = health.ToString();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void levelEnd()
    {
        // Find all objects tagged as "Enemy"
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Birds");

        // Loop through each enemy and destroy them
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }

        birdSound.Stop(); // Stop the bird sound
    }

    //// Function to stop enemy spawning
    //void StopEnemySpawning()
    //{
    //    if (enemySpawner != null)
    //    {
    //        Spawner spawner = enemySpawner.GetComponent<Spawner>();
    //        if (spawner != null)
    //        {
    //            spawner.StopSpawning(); // Custom function in the spawner script to stop spawning
    //        }
    //    }
    //}


    public void TakeDamage(int damageAmount)
    {
        //source.Play();
        health -= damageAmount;
        healthDisplay.text = health.ToString();

        if (health <= 0)
        {
            health = 0;
            healthDisplay.text = health.ToString();
            Destroy(gameObject);
            loseText.text = "Oops !! You Are Dead..";
            losePanel.SetActive(true);
            levelEnd();
            //StopEnemySpawning();
        }
    }

    // Method to increment the score
    public void IncrementScore()
    {
        score++;
        UpdateScoreDisplay();
    }

    // Update score display
    private void UpdateScoreDisplay()
    {
        if (scoreDisplay != null)
        {
            scoreDisplay.text = "Score: " + score;
        }
    }

}
