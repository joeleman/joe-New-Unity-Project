using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemymove : MonoBehaviour
{

    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float ex = transform.position.x;

        float px = player.transform.position.x;




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


        if (ex < px)
        {
            DoFaceLeft(true);
        }
        else
        {
            DoFaceLeft(false);
        }



    }

}
