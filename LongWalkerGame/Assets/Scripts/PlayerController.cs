using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    public float speed;
    public float WalkSpeed;
    public float RunSpeed;
    public bool isRunning = false;
    public float jumpSpeed;            

    [SerializeField] private AudioClip[] m_FootstepSounds;    // an array of footstep sounds that will be randomly selected from.
    [SerializeField] private AudioClip m_JumpSound;           // the sound played when character leaves the ground.
    [SerializeField] private AudioClip m_LandSound;           // the sound played when character touches back on ground.

    public AnimationCurve SlopeCurveModifier = new AnimationCurve(new Keyframe(-90.0f, 1.0f), new Keyframe(0.0f, 1.0f), new Keyframe(90.0f, 0.0f));
    private AudioSource m_AudioSource;
    //  public Weapons[] weapons;



    //  public int index;

    public int PlayerHealth = 100;
    
	// Use this for initialization
	void Start ()
    {
        // this  function is called to lock the cursor in game mode
        Cursor.lockState = CursorLockMode.Locked;
        m_AudioSource = GetComponent<AudioSource>();
    }


    void FixedUpdate()
    {
        // PlayerMovement
        float moveHor = Input.GetAxis("Horizontal") * WalkSpeed * Time.fixedDeltaTime * speed;
        float moveVert = Input.GetAxis("Vertical") * WalkSpeed * Time.fixedDeltaTime * speed;
        transform.Translate(moveHor, 0, moveVert);
        //transform.Rotate(0, 0, moveVert);
        float Jump = Input.GetAxis("Jump") * jumpSpeed * Time.fixedDeltaTime;
        transform.Translate(moveHor, Jump, moveVert);
    }
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKey(KeyCode.W)&& Input.GetKey(KeyCode.LeftShift))
        {
            isRunning = true;
            speed = RunSpeed ;
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


    private void PlayFootStepAudio()
    {
        {
            return;
        }
        // pick & play a random footstep sound from the array,
        // excluding sound at index 0
        int n = Random.Range(1, m_FootstepSounds.Length);
        m_AudioSource.clip = m_FootstepSounds[n];
        m_AudioSource.PlayOneShot(m_AudioSource.clip);
        // move picked sound to index 0 so it's not picked next time
        m_FootstepSounds[n] = m_FootstepSounds[0];
        m_FootstepSounds[0] = m_AudioSource.clip;
    }
}
