﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

    private Animator anim;
    private AudioSource AdiouS;
	// Use this for initialization
	void Start () {

        anim = GetComponent<Animator>();
        AdiouS = GetComponent<AudioSource>();
	}

    void OnTriggerEnter(Collider col)
    {
       
        
            anim.SetBool("isOpen", true);
        AdiouS.Play();
       
    }

    void OnTriggerExit (Collider col)
    {
      
        
            anim.SetBool("isOpen", false);
        AdiouS.Play();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}