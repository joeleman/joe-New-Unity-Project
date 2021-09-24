using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playermove : MonoBehaviour
{
    private Rigidbody2D rb;
    bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        DoJump();
        DoMove();

    }

    void DoJump()
    {
        Vector2 velocity = rb.velocity;

        // check for jump
        if (Input.GetKey("j") && (isGrounded==true))
        {
            if (velocity.y < 0.01f)
            {
                velocity.y = 10f;    // give the player a velocity of 5 in the y axis

            }
        }

        rb.velocity = velocity;

    }

    void DoMove()
    {
        Vector2 velocity = rb.velocity;

        // stop player sliding when not pressing left or right
        velocity.x = 0;

        // check for moving left
        if (Input.GetKey("z"))
        {
            velocity.x = -5;
        }

        // check for moving right
        if (Input.GetKey("x"))
        {
            velocity.x = 5;
        }
        rb.velocity = velocity;

    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

}