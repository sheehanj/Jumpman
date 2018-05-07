//John Sheehan III
//Jumpman

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private bool grounded;
    private bool facingRight;
    private bool restart;
    private int score;

    public float speed;
    public float jumpSpeed;
    

    public Text scoreCount;
    public Text finalScore;
    public Text restartText;
   
  

	void Start ()
    {
        rb2d = this.GetComponent<Rigidbody2D>();
        score = 0;
        restart = false;
        restartText.text = "";
        finalScore.text = "";
	}

    void Update()
    {
        if(restart)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }
    }

    void FixedUpdate ()
    {
        //Move the Player left and right
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        Vector2 moveVel = rb2d.velocity;
        moveVel.x = moveHorizontal * speed;
        rb2d.velocity = moveVel;

        //Check direction and flip the Player
        if (moveHorizontal > 0 && facingRight)
            Flip();

        else if (moveHorizontal < 0 && !facingRight)
            Flip();

        //Make the Player jump
        if (Input.GetKey(KeyCode.UpArrow) && grounded)
        {
            rb2d.velocity += jumpSpeed * Vector2.up;
            grounded = false;
        }

	}

    //Check for collision between a Player and a Platform
    private void OnCollisionEnter2D(Collision2D collision)
    {
        {
            if (collision.gameObject.CompareTag("Platform"))
            {
                grounded = true;
                score += 50;
                UpdateScore();
           
   
            }

            else if(collision.gameObject.CompareTag("Bottom"))
            {
                restartText.text = "Press 'R' to Play Again!";
                finalScore.text = "Final Score: " + score;
                restart = true;
            }
        }
    }

    //Flip the direction the Player is facing
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    //Update and Overwrite UI Text Object
    private void UpdateScore()
    {
        scoreCount.text = "Score: " + score.ToString();
    }

}
