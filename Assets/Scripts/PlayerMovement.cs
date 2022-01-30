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

    private Animator animator;
    
    private float horizontalMove = 0.0f;
    private bool jump = false;

    private BoxMovement grabbedBox = null;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // todo: player shouldn't be able to move during cutscenes
        // todo: stop dragging if no longer touching the ground

        if (Input.GetButtonUp(InputDrag) && grabbedBox != null)
        {
            grabbedBox.transform.parent = null;
            grabbedBox.Release();
            grabbedBox = null;
        }

        if (grabbedBox != null)
        {
            // when dragging, speed is reduced
            horizontalMove = Input.GetAxisRaw(InputAxis) * dragSpeed;
            animator.SetBool("isPushPulling", true);
        }
        else
        {
            horizontalMove = Input.GetAxisRaw(InputAxis) * speed;
            animator.SetBool("isPushPulling", false);

            // can only jump if not dragging
            if (Input.GetButtonDown(InputJump))
            {
                jump = true;
                animator.SetBool("isJumping", true);
            }
        }

        animator.SetBool("isMoving", horizontalMove != 0);

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
            bool pull = (move > 0 && !controller.m_FacingRight) || (move < 0 && controller.m_FacingRight);

            if ((black && pull) || (!black & !pull))
            {
                controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, false);
            }
        }
        else
        {
            controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump, true);
        }

        // reset the jump flag
        jump = false;
        animator.SetBool("isJumping", false);
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
        // Check that this box is to our side, not below us
        float yDiff = transform.position.y - collision.gameObject.transform.position.y;

        if (collision.gameObject.CompareTag("Box") && yDiff < 4.0f)
        {
            // Try to pair with the box
            if (Input.GetButton(InputDrag) && grabbedBox == null)
            {
                // Make sure both cats can't pick up at once
                BoxMovement box = collision.gameObject.GetComponent<BoxMovement>();
                if (!box.isGrabbed)
                {
                    grabbedBox = box;
                    grabbedBox.transform.parent = transform;
                    grabbedBox.Grab();
                }
            }
        }
    }
}
