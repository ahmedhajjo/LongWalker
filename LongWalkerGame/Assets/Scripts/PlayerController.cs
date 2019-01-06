using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float WalkSpeed;
    public float RunSpeed;
    public bool isRunning = false;
    public bool isWalking = false;

    public float jumpSpeed;
    bool isGrounded;
    Rigidbody rb;
    public AudioSource footStepsAudio,runninAudio,JumpAudio;
    public Animator anim;
    
    //  public Weapons[] weapons;



    //  public int index;

    public int PlayerHealth = 100;
    float moveHor;
    float moveVert;

    // Use this for initialization
    void Start()
    {
      
        rb = GetComponent<Rigidbody>();
        // this  function is called to lock the cursor in game mode
        Cursor.lockState = CursorLockMode.Locked;
    }


    void FixedUpdate()
    {
        // PlayerMovement
        moveHor = Input.GetAxis("Horizontal") * WalkSpeed * Time.fixedDeltaTime * speed;
        moveVert = Input.GetAxis("Vertical") * WalkSpeed * Time.fixedDeltaTime * speed;
        transform.Translate(moveHor, 0, moveVert);
        
        //transform.Rotate(0, 0, moveVert);


    }
    // Update is called once per frame
    void Update()
    {

        Jump();


        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A)) && !isRunning)
        {
            if(!footStepsAudio.isPlaying)
            {
                footStepsAudio.Play();
                anim.SetBool("ISwalk", true);


            }
            
        }

        else
        {
            footStepsAudio.Stop();

            anim.SetBool("ISwalk", false);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))
        {

            footStepsAudio.Stop();
            if (!runninAudio.isPlaying)
            {

                runninAudio.Play();

            }

         

            isRunning = true;
            speed = RunSpeed;
            Debug.Log("running");
            
        }

        else
        {
           
            isRunning = false;
            speed = WalkSpeed;
        }
          
        
        // EXCAPE Button To enable the Cursor
        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            
        }



        /* if (Input.GetKeyDown(KeyCode.Alpha1))
         {
             weapons[index].gameObject.SetActive(false);
             index = 0;
             weapons[index].gameObject.SetActive(true);
         }

         if (Input.GetKeyDown(KeyCode.Alpha2))
         {
             weapons[index].gameObject.SetActive(false);
             index = 1;
             weapons[index].gameObject.SetActive(true);
         }

         if (Input.GetKeyDown(KeyCode.Alpha3))
         {
             weapons[index].gameObject.SetActive(false);
             index = 2;
             weapons[index].gameObject.SetActive(true);
         }
         */

    }

    public void ApplyDamage(int Dmg)
    {
        PlayerHealth = PlayerHealth - Dmg;

    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        { isGrounded = true; }
    }

void Jump()
{
    if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {            
            isGrounded = false;
            rb.AddForce(transform.up * 120);

            JumpAudio.Play();
            
        }

}

       


}
