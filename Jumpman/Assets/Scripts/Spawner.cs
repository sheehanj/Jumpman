//John Sheehan III
//Jumpman

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    
    private float speedTimer;
    private float spawnTimer;
    private float spawnRate;
    private float speed;
    private float maxSpeed;
    public GameObject platformPrefab;


    // Use this for initialization
    void Start ()
    {
        speed = .05f;
        maxSpeed = .4f;
        spawnRate = 5f;
        SpawnPlatform();
    }
	
	// Update is called once per frame
	void Update ()
    {
        spawnTimer += Time.deltaTime;
        speedTimer += Time.deltaTime;

        //Spawn a platform based on the time passed since the last spawn
        if (spawnTimer >= spawnRate)
        {
            SpawnPlatform();
            spawnTimer = 0;
        }

        //Every 10 seconds increase the speed of the platforms
        if (speedTimer >= 10)
        {
            //A max speed setting so the game does not become impossible
            if (speed < maxSpeed)
                increaseSpeed();

            //Spawn rate calibrated to stay balanced with the increasing speed of the platforms
            if (spawnRate == 1f)
                spawnRate = 1f;
            else if (spawnRate <= 2f)
                spawnRate -= .25f;
            else
                spawnRate -= 1.5f;


            speedTimer = 0;
        }

    }

    //Method to spawn a platform at the right edge of the screen with a random y position
    void SpawnPlatform()
    {
        GameObject platform = Instantiate(platformPrefab) as GameObject;
        float randY = Random.Range(-5f, -2f);
        Vector2 pos = new Vector2(24, randY);
        platform.transform.position = pos;

        //call the set speed method in PlatformController.cs 
        //allows new platforms to spawn with the current global speed
        platform.GetComponent<PlatformController>().setSpeed(speed);      
    }

    //simple method to increase speed of platforms
    public void increaseSpeed()
    {
        speed += 0.02f;
    }
}
