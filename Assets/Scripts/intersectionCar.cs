using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class intersectionCar : MonoBehaviour
{
    bool crashcheck = false;
    bool rotatecheck = true;
    public float carspeed;
    public float speedLimit;
    private Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        
        rb = GetComponent<Rigidbody>();

        rb.AddForce(Vector3.back * carspeed, ForceMode.Impulse);

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (crashcheck == false && rotatecheck == true)
        {
            if (rb.velocity.magnitude < speedLimit)
            {
                transform.rotation = Quaternion.Euler(0f, 180f, 0f);
                rb.AddForce(Vector3.back * carspeed, ForceMode.Impulse);
            }

        }
        if (crashcheck == false && rotatecheck == false)
        {
            if (rb.velocity.magnitude < speedLimit)
            {
                transform.rotation = Quaternion.Euler(0f, 0f, 0f);
                rb.AddForce(Vector3.forward * carspeed, ForceMode.Impulse);
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

        if(collision.collider.tag == "rotatechanger")
        {
            rotatecheck = !rotatecheck;
        }


    }




    
}
