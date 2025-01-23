using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public Transform[] spawnPoints;
    public GameObject[] hazards;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public float minTimeBtwSpawns;
    public float decrease;
    public GameObject player;

    //public AudioSource birdSound;

    //private bool isPaused = false;  // Track if the game is paused

    //private bool stopSpawning = true;

    // Update is called once per frame
    void Update()
    {
        //if (!stopSpawning)
        //{

            if (player != null)
            {
                if (timeBtwSpawns <= 0)
                {
                    Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
                    GameObject randomHazard = hazards[Random.Range(0, hazards.Length)];

                    Instantiate(randomHazard, randomSpawnPoint.position, Quaternion.identity);

                if (startTimeBtwSpawns > minTimeBtwSpawns)
                    {
                        startTimeBtwSpawns -= decrease;
                    }

                    timeBtwSpawns = startTimeBtwSpawns;
                }
                else
                {
                    timeBtwSpawns -= Time.deltaTime;
                }
            }
        //}
    }

    //private void PlayFireSound()
    //{
    //    if (birdSound != null)
    //    {
    //        birdSound.Play(); // Plays the bird sound on game start
    //    }
    //}

    //// Method to pause/unpause the spawner
    //public void ToggleSpawnerPause(bool pause)
    //{
    //    isPaused = pause;
    //}

    //internal void StopSpawning()
    //{
    //   stopSpawning = true;
    //}
}