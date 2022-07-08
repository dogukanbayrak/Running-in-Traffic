using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rightlinecarMovement : MonoBehaviour
{
    bool crashcheck = false;
    public float carspeed;
    public float speedLimit;
    private Rigidbody rb;

    void Start()
    {
       
        rb= GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        if (crashcheck == false)
        {
            if (rb.velocity.magnitude < speedLimit)
            {
                rb.AddForce(Vector3.right * carspeed, ForceMode.Impulse);
            }

        }

        if (crashcheck == true)
        {
            GetComponent<Rigidbody>().velocity = Vector3.zero;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {

            crashcheck = true;
        }
    }
}
