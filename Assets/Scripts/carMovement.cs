using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class carMovement : MonoBehaviour
{

    public Rigidbody rb;

    [Range(1f,30f)]
    public float speed;
    public float carspeedlimit;
    public float horizontalSpeed;
    bool enemyCheck = false;
    public Joystick joystick;
    Vector3 joystickspeed;
    public float fuelRate;
    fuelSystem fuelSystem;
    
    void Start()
    {
        fuelSystem = GetComponent<fuelSystem>();
        
    }

    
    void FixedUpdate()
    {
        if (fuelSystem.startFuel > 1 && enemyCheck == false && rb.velocity.magnitude < carspeedlimit)
        {
            rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
        }

        if (fuelSystem.startFuel <= 0)
        {
            Invoke("restart", 2f);
        }

        fuelSystem.fuelConsumptionRate = fuelRate;
        fuelSystem.ReduceFuel();

        joystickspeed = new Vector3(joystick.Horizontal, 0f);

        if (joystick.Horizontal > 0.5f && enemyCheck == false)
        {
            rb.AddForce(Vector3.forward * -horizontalSpeed, ForceMode.Impulse);
            transform.rotation = Quaternion.Euler(0f, 95f, 0f);

        }
        if (joystick.Horizontal < -0.5f && enemyCheck == false)
        {
            rb.AddForce(Vector3.back * -horizontalSpeed, ForceMode.Impulse);
            transform.rotation = Quaternion.Euler(0f, 85f, 0f);
        }

        if (   0.5f > joystick.Horizontal && joystick.Horizontal > -0.5f && enemyCheck == false)
        {
            
            transform.rotation = Quaternion.Euler(0f, 90f, 0f);
        }



    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "Fuel")
        {

            Destroy(collision.gameObject);
            fuelSystem.startFuel += 40f;

        }

        if (collision.gameObject.tag == "Enemy")
        {
            enemyCheck = true;
            Invoke("restart", 2f);
        }

        if (collision.gameObject.tag == "nextlevel")
        {
            nextChapter();
        }

        if (collision.gameObject.tag == "lastlevel")
        {
            SceneManager.LoadScene("chapterone");
        }
    }
    void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void nextChapter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
