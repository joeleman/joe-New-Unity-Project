using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        public PortalChecker otherPortal;
        public bool receiving = false;
    }


    // Update is called once per frame
    void Update()
    {
        void OnTriggerEnter2D(Collider2D coll)
        {
            if (!receiving)
            {
                otherPortal.receiving = true;
                coll.gameObject.transform.position = otherPortal.gameObject.transform.position;
            }
            receiving = false;
        }
    }
}
