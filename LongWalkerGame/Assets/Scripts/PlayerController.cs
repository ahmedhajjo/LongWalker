using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed;  //Speed
    public float WalkSpeed; //Walk
    public float RunSpeed; //Run
    public bool isRunning = false;  //Bool isRunning
  

    private float bloodCtrl; //Blood

    public int jumpSpeed = 120;  //Jump
    bool isGrounded;  //Bool isGrounded
    Rigidbody rb;  
    public AudioSource footStepsAudio, runninAudio, JumpAudio;  //Audios
    public Animator anim;
    public static bool GamePaused = false;
    public GameObject PauseMenu;
    public Transform Canvas;

    public int PlayerHealth = 100;
    public RawImage BloodImage;
    float moveHor;
    float moveVert;

    public Transform Ak, m4,aimWeapon, MouseCam;


    // Use this for initialization

    private void Awake()
    {
        Cursor.visible = false;
    }


    void Start()
    {
       
        rb = GetComponent<Rigidbody>();
      
    }


    void FixedUpdate()
    {
        // PlayerMovement
        moveHor = Input.GetAxis("Horizontal") * WalkSpeed * Time.fixedDeltaTime * speed;  
        moveVert = Input.GetAxis("Vertical") * WalkSpeed * Time.fixedDeltaTime * speed;
        transform.Translate(moveHor, 0, moveVert);

   


    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerHealth <= 0)  //dead go to Main Menu Scene
        {
            SceneManager.LoadScene(0);
            Cursor.visible = true;

        }

        
        if (bloodCtrl > 0)  //Blood Image
        {
            bloodCtrl -= 0.005f;  
            BloodImage.color =  new Color(1,1,1,Mathf.Lerp(0, 1, bloodCtrl));  //Slow Subtract From Alpha Color
        }


        Jump(); //Jump Function


        if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A)) && !isRunning) //Play WASD 
        {
            if (!footStepsAudio.isPlaying)
            {
                footStepsAudio.Play(); //Player Audio
                anim.SetBool("ISwalk", true);  //PLay Animation
            }

        }

        else
        {
            footStepsAudio.Stop();     //Stop Audio
            anim.SetBool("ISwalk", false);    // Stop Anim
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))  //Run W+Left Shift
        {

            footStepsAudio.Stop();   //Stop Audio of Walk
            if (!runninAudio.isPlaying)
            {
                runninAudio.Play(); //Play Run Audio
            }

            isRunning = true;  //Run
            speed = RunSpeed;  //Change Speed to Run Speed 
            Debug.Log("running"); //DEBUG
        }

        else
        {
            isRunning = false; //Walk Mode
            speed = WalkSpeed;
        }


        
        // EXCAPE Button To enable the Cursor

        
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            Paused();

        }
    }

    public void ApplyDamage(int Dmg)
    {
        PlayerHealth = PlayerHealth - Dmg;
        BloodImage.color = new Color(255, 255, 255, 255);
        bloodCtrl = 1;
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
            rb.AddForce(transform.up * jumpSpeed);

            JumpAudio.Play();

        }

    }



   public void Paused()
    {
        if (Canvas.gameObject.activeInHierarchy == false)
        {
            Canvas.gameObject.SetActive(true);
            Time.timeScale = 0;
            Debug.Log("Cursors");
            Cursor.visible = true;
            transform.GetComponent<PlayerController>().enabled = false;
            m4.GetComponent<Weapons>().enabled = false;
            Ak.GetComponent<Weapons>().enabled = false;
            MouseCam.GetComponent<MouseCam>().enabled = false;
            
        }
        else
        {
            Canvas.gameObject.SetActive(false);
            Time.timeScale = 1f;
            Cursor.visible = false;
            transform.GetComponent<PlayerController>().enabled = true;
            m4.GetComponent<Weapons>().enabled = true;
            Ak.GetComponent<Weapons>().enabled = true;
            MouseCam.GetComponent<MouseCam>().enabled = true;
            aimWeapon.GetComponent<AimWeapon>().enabled = true;
        }

    }
}
