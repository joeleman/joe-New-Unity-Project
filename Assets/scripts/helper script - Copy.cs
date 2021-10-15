using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helper : MonoBehaviour
{


    public static void DoFaceLeft(GameObject obj, bool left)
    {
        if (left == true)
        {
            obj.transform.localRotation = Quaternion.Euler(0, 180, 0);

        }
        else
        {
            obj.transform.localRotation = Quaternion.Euler(0, 0, 0);

        }
    }

    public static bool GetDirection(GameObject obj)
    {


        if (obj.transform.eulerAngles.y == 180)
        {
            return true;
        }
        else
        {
            return false;
        }

    }


    public static void EnemyDirection(GameObject player, GameObject enemy)
    {
        Rigidbody2D rb;

        float ex = enemy.transform.position.x;
        float px = player.transform.position.x;

        rb = enemy.GetComponent<Rigidbody2D>();




        float playerdistance = ex - px;

        if (playerdistance > 3)
        {

            rb.velocity = new Vector3(-2, 0, 0);
            DoFaceLeft(enemy, true);
        }
        else if (playerdistance < -3)
        {

            rb.velocity = new Vector3(2, 0, 0);
            DoFaceLeft(enemy, false);
        }
        else
        {

            rb.velocity = new Vector3(0, 0, 0);

        }
    }
    public static void SetVelocity(GameObject obj, float xv, float yv)
    {
        Rigidbody2D rb = obj.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(xv, yv, 0);
     
    }

    /*
    void DoRayCollisionCheck()
{
        float rayLength = 1.0f;
 
	//cast a ray downward of length 1
        RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, rayLength);
       
        Color hitColor = Color.white;
       
       
        if (hit.collider != null)
        {
 
            if( hit.collider.tag == "Player")
            {
                print("Player has collided with Enemy" );
                hitColor = Color.red;
            }
 
            if( hit.collider.tag == "Ground")
            {
                print("Player has collided with Ground" );
                hitColor = Color.green;
            }
        }
	// draw a debug ray to show ray position
	// You need to enable gizmos in the editor to see these
        Debug.DrawRay(transform.position, -Vector2.up * rayLength, hitColor);
 
}
 
    */


}