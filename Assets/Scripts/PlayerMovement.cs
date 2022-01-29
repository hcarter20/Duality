using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string InputAxis;
    public string InputJump;
    public CharacterController2D controller;
    public float speed;

    // private Animator animator;
    
    private float horizontalMove = 0.0f;
    private bool jump = false;


    private void Start()
    {
        // animator = GetComponent<Animator>();
    }

    void Update()
    {
        // player shouldn't be able to move outside of playing state

        horizontalMove = Input.GetAxisRaw(InputAxis) * speed;

        if (Input.GetButtonDown(InputJump))
            jump = true;

        // get the approximate direction
        // float ourSpeed = Input.GetAxis("Horizontal");
        // animator.SetFloat("speed", Mathf.Abs(ourSpeed));
    }

    private void FixedUpdate()
    {
        /*
        // check if past the finish line
        if (transform.position.x > 261.0f && GameManager.S.gameState == GameState.playing)
        {
            // tell the GameManager that the player reached the finish line
            GameManager.S.GameOverState(true);
        }
        */

        // move the player in the fixed update
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);

        /*
        if (jump)
        {
            // make a jump sound
            SoundManager.S.PlayJumpSound();

            // start jump animation
            animator.SetBool("isOnGround", false);
        }
        */

        // reset the jump flag
        jump = false;
    }

    /* CharacterController2D tends to double-fire the 'OnLanded' event, 
     * but sometimes it works perfectly, so I can't necessarily skip this. */
    public void PlayerLanded()
    {
        /*
        if (animator != null)
        {
            animator.SetBool("isOnGround", true);
        }
        */
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
    }

    /* The head of the enemy is a trigger, the body of the enemy is a rigidbody */
    private void OnCollisionEnter2D(Collision2D collision)
    {
    }
}
