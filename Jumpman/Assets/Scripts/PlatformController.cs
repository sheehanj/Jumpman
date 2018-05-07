//John Sheehan III
//Jumpman

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    private static float speed;

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move the platforms to the left according to the current speed
        Vector2 pos = transform.position;
        pos.x -= speed;
        transform.position = pos;

        //Destroy a platform after it is off the screen
        if (transform.position.x <= -22)
            Destroy(gameObject);
    }

    //Method used by spawner.cs to increase platform speed globally
    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
    }
    
}
