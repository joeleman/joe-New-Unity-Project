


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class duckmove : MonoBehaviour
{
    private Rigidbody2D rb;
    bool isGrounded;
    public Transform firePoint;
    private Animator anim;
    public GameObject knife;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        DoJump();
        DoMove();
        DoShoot();

    }






    void DoJump()
    {
        Vector2 velocity = rb.velocity;

        // check for jump
        if (Input.GetKey("w") && (isGrounded == true))
        {
            if (velocity.y < 0.01f)
            {
                velocity.y = 8f;    // give the player a velocity of 5 in the y axis

            }
        }

        if (velocity.y != 0)
        {
            anim.SetBool("duckjump", true);
        }
        else
        {
            anim.SetBool("duckjump", false);
        }

        rb.velocity = velocity;

    }





    void DoMove()
    {

        anim.SetBool("duckwalk", false);


        // check for moving left
        if (Input.GetKey("a"))
        {
            Helper.SetVelocity(gameObject, -5,0 );
            anim.SetBool("duckwalk", true);
        }

        // check for moving right
        if (Input.GetKey("d"))
        {
            Helper.SetVelocity(gameObject, 5, 0);
            anim.SetBool("duckwalk", true);
        }

      
       

    }
    void DoFaceLeft(bool faceleft)
    {
        if (faceleft == true)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }





    
    private void OnCollisionStay2D(Collision2D collosion)
    {
        isGrounded = true;
       // Helper.DoRayCollisionCheck();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
        //Helper.DoRayCollisionCheck();
    }

    private void FixedUpdate()
    {
        Vector2 velocity = rb.velocity;
        if (velocity.x > 0)
        {
            transform.localScale = new Vector3(1f, 1f, 0.5f);
        }
        else if (velocity.x < 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 0.5f);
        }
    }





    void DoShoot()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject obj=Instantiate(knife, transform.position + new Vector3(0, 0 + 0, 0), Quaternion.identity);
            

            Helper.SetVelocity(obj, 3, 0);

           /* void KnifeFaceLeft(bool knifeleft)
            {
                while (Input.getkey == a) 
                    (knifeleft == true);
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }*/

        }
    }
       
}