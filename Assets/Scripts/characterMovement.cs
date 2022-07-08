using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class characterMovement : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float jumpingSpeed;
    public float gravitySpeed;
    public float horizontalSpeed;
    //public Animator animator;
    public bool jumpCheck;
    bool enemyCheck = false;
    public Animator anim;
    public Joystick joystick;
    Vector3 joystickspeed;

    fuelSystem fuelSystem;
    


   
    void Start()
    {
        anim = GetComponent<Animator>();
        fuelSystem = GetComponent<fuelSystem>();
        
    }

    
    void FixedUpdate()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");
        float yMov = Input.GetAxisRaw("Jump");

        //rb.velocity = Vector3.left * speed;
        if(fuelSystem.startFuel> 1 && enemyCheck == false)
        {
            rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
        }

        if(fuelSystem.startFuel <= 0)
        {
            Invoke("restart", 2f);
        }
        


        fuelSystem.fuelConsumptionRate = speed * 0.3f;
        fuelSystem.ReduceFuel();


        rb.velocity = Vector3.down * gravitySpeed;
        joystickspeed = new Vector3(joystick.Horizontal, 0f);

        
        if (joystick.Horizontal > 0.5f && enemyCheck == false )
        {
            rb.AddForce(Vector3.forward * -horizontalSpeed, ForceMode.Impulse);
        }
        if (joystick.Horizontal < -0.5f && enemyCheck == false)
        {
            rb.AddForce(Vector3.back * -horizontalSpeed, ForceMode.Impulse);
        }



    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpCheck=false;
            anim.SetBool("jumpingAnimCheck",false);
            
        }

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

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            jumpCheck=true;            
            anim.SetBool("jumpingAnimCheck", true);
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
