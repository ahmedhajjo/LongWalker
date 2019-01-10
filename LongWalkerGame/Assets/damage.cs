using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damage : MonoBehaviour {





    PlayerController PlayerScript;
    public GameObject Player;
	// Use this for initialization
	void Start () {
        PlayerScript = Player.GetComponent<PlayerController>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            PlayerScript.PlayerHealth -= 10;
            Debug.Log(PlayerScript.PlayerHealth);
        }
    }
}
