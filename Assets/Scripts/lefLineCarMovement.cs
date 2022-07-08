using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lefLineCarMovement : MonoBehaviour
{
    bool crashcheck = false;
    public float carspeed;
    public float speedLimit;
    private Rigidbody rb;


    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (crashcheck == false)
        {
            if (rb.velocity.magnitude < speedLimit)
            {
                rb.AddForce(Vector3.left * carspeed, ForceMode.Impulse);
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
