using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public Animator anim;
    private AudioSource AdiouS;
    public bool Access;
    // Use this for initialization
    void Start()
    {
        AdiouS = GetComponent<AudioSource>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (Access)
        {
            anim.SetBool("isOpen", true);
            AdiouS.Play();
        }

    }

    void OnTriggerExit(Collider col)
    {
        if (Access)
        {
            anim.SetBool("isOpen", false);
            AdiouS.Play();
        }

    }

}
