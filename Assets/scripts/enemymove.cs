using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{

    private Rigidbody2D rb;
    public GameObject player;
    /*bool isGrounded;*/
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        DoMove();
       // DoJump();
        
    }

    void DoMove()
    {
     

        Vector2 velocity = rb.velocity;

        float ex = transform.position.x;
        // above and below are variables for player and enemy 
        float px = player.transform.position.x;

        if (ex > px)
        {
            DoFaceLeft(true);
            velocity.x = -4;
        }
       

        else
        {
            DoFaceLeft(false);
            velocity.x = 4;
        }


        rb.velocity = velocity;
    }


    
    /*void DoJump()
    {
        Vector2 velocity = rb.velocity;

        float ey = transform.position.y;

        float py = player.transform.position.y;

        if (ey < py)
        {

            if (velocity.y < 0.01f)

            {
                velocity.y = 2f;    
                

            }
        }

        rb.velocity = velocity;
        
         
        
    }
    */
  
    void DoFaceLeft(bool faceleft)
    {
        if (faceleft == false)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
    /*
    private void OnCollisionStay2D(Collision2D collosion)
    {
        isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }
*/}
