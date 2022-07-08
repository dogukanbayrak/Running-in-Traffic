using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chapterOneCharacter : MonoBehaviour
{

    public Rigidbody rb;
    public float speed;
    public float jumpingSpeed;
    public float gravitySpeed;
    public float horizontalSpeed;
    public bool jumpCheck;
    bool enemyCheck = false;
    public Animator anim;
    public Joystick joystick;
    Vector3 joystickspeed;
       



    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");
        float yMov = Input.GetAxisRaw("Jump");

        //rb.velocity = Vector3.left * speed;
        if (enemyCheck == false)
        {
            rb.AddForce(Vector3.right * speed, ForceMode.Impulse);
        }

        rb.velocity = Vector3.down * gravitySpeed;
        joystickspeed = new Vector3(joystick.Horizontal, 0f);

        //rb.AddForce(0, gravitySpeed, 0);

        if (joystick.Vertical > 0.5f && jumpCheck == false)
        {
            rb.AddForce(Vector3.up * jumpingSpeed, ForceMode.Impulse);
        }
        if (joystick.Horizontal > 0.5f && enemyCheck == false)
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
        if (collision.gameObject.tag == "Ground")
        {
            jumpCheck = false;
            anim.SetBool("jumpingAnimCheck", false);

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
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpCheck = true;
            anim.SetBool("jumpingAnimCheck", true);
        }
        
        
        
    }

    public void nextChapter()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void restart ()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
