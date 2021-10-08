


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public Transform firePoint;
public class duckmove : MonoBehaviour
{
    private Rigidbody2D rb;
    bool isGrounded;
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
        Vector2 velocity = rb.velocity;

        // stop player sliding when not pressing left or right
        velocity.x = 0;

        // check for moving left
        if (Input.GetKey("a"))
        {
            velocity.x = -5;
        }

        // check for moving right
        if (Input.GetKey("d"))
        {
            velocity.x = 5;
        }

        if (velocity.x != 0)
        {
            anim.SetBool("duckwalk", true);
        }
        else
        {
            anim.SetBool("duckwalk", false);
        }

        rb.velocity = velocity;

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
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
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
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        Instantiate(knife, firePoint.position, firePoint.rotation);
    }
    

    public static void Shoot(GameObject prefab, float xpos, float ypos, float xvel, float yvel)
    {
        GameObject instance = Instantiate(prefab, new Vector3(xpos, ypos, 0), Quaternion.identity);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(6, 0, 0);
        //FlipObject(instance, xvel <0?Left:Right);

    }





}