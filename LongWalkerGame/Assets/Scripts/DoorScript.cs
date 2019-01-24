using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public Animator anim;
    private AudioSource AdiouS;
    public bool Access;
    public bool isTrap = false;
    public GameObject door;

    void Start()
    {
        AdiouS = GetComponent<AudioSource>();
        if (isTrap)// open the door trap at the start                                     
        {
            anim.SetBool("isOpen", true);
        }
    }

    void OnTriggerEnter(Collider col)
    {

        if (!isTrap )// if the door is not trap open when the player enter
        {
            if (Access)
            {
                anim.SetBool("isOpen", true);
                AdiouS.Play();
            }
        }
        else if (isTrap && col.tag== "Player") // if trap is true close the door
        {
            anim.SetBool("isOpen", false);
            AdiouS.Play();
            
            
        }
     
    }

    void OnTriggerExit(Collider col)
    {
        if (!isTrap)// if not a trap close on exit
        {
            if (Access)
            {
                anim.SetBool("isOpen", false);
                AdiouS.Play();
            }
        }


      
    }

}
