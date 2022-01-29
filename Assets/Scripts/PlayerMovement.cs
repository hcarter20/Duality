using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public string InputAxis;
    public string InputJump;
    public string InputDrag;
    public CharacterController2D controller;
    public float speed;
    public float dragSpeed;
    public bool black;

    // private Animator animator;
    
    private float horizontalMove = 0.0f;
    private bool jump = false;

    private BoxMovement grabbedBox;

    private void Start()
    {
        // animator = GetComponent<Animator>();
    }

    void Update()
    {
        // todo: player shouldn't be able to move during cutscenes
        // todo: stop dragging if no longer touching the ground

        if (Input.GetButtonUp(InputDrag))
        {
            if (grabbedBox != null)
            {
                grabbedBox.transform.parent = null;
                grabbedBox = null;
                Debug.Log("Box is released.");
            }
        }

        if (grabbedBox != null)
        {
            // when dragging, speed is reduced
            horizontalMove = Input.GetAxisRaw(InputAxis) * dragSpeed;
        }
        else
        {
            horizontalMove = Input.GetAxisRaw(InputAxis) * speed;

            // can only jump if not dragging
            if (Input.GetButtonDown(InputJump))
                jump = true;
        }

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

        if (grabbedBox != null)
        {
            // Check if we're moving opposite direction of facing
            float move = horizontalMove * Time.fixedDeltaTime;

            if ((move > 0 && !controller.m_FacingRight) || (move < 0 && controller.m_FacingRight))
            {
                if (black)
                {
                    controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, false);
                }
                else
                {
                    Debug.Log("White cat cannot pull.");
                }
            }
            else
            {
                if (!black)
                {
                    controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, false);
                }
                else
                {
                    Debug.Log("Black cat cannot push.");
                }
            }
        }
        else
        {
            // move the player in the fixed update
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, true);
        }

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

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            // see if the player is trying to drag a box
            if (Input.GetButton(InputDrag))
            {
                // Tell the box that we're paired
                grabbedBox = collision.gameObject.GetComponent<BoxMovement>();
                if (grabbedBox != null)
                {
                    grabbedBox.Grab();
                    grabbedBox.transform.parent = transform;
                }
            }
        }
    }
}
