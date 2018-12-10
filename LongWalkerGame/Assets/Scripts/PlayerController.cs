using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float WalkSpeed;
    public float RunSpeed;
    public bool isRunning = false;
    public float jumpSpeed;

    public Weapons[] weapons;

    public int index;

    public int PlayerHealth = 100;
    
	// Use this for initialization
	void Start ()
    {
        // this  function is called to lock the cursor in game mode
        Cursor.lockState = CursorLockMode.Locked;
	}


    void FixedUpdate()
    {
        // PlayerMovement
        float moveHor = Input.GetAxis("Horizontal") * WalkSpeed * Time.deltaTime;
        float moveVert = Input.GetAxis("Vertical") * WalkSpeed * Time.deltaTime;
        transform.Translate(moveHor, 0, moveVert);

        float Jump = Input.GetAxis("Jump") * jumpSpeed * Time.deltaTime;
        transform.Translate(moveHor, Jump, moveVert);
    }
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(KeyCode.W)&& Input.GetKey(KeyCode.LeftShift))
        {
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



        if (Input.GetKeyDown(KeyCode.Alpha1))
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


    } 

    public void ApplyDamage(int Dmg)
    {
        PlayerHealth = PlayerHealth - Dmg;
       
    }



}
