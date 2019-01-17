using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour {


    
    public GameObject[] weapons;    //WeaponArrays
    public int index;               //Gun Index
	
	// Update is called once per frame
	void Update () {
        SwipGuns();
	}


    public void SwipGuns()       //Switch Guns Function
    {
        //isRealoading = info.IsName("GunIn");

        if (Input.GetKeyDown(KeyCode.Alpha1))     //Input ALPHA 1
        {
            weapons[index].gameObject.SetActive(false);  //Disable Current Gun
            index = 0; // Gun ID
            weapons[index].gameObject.SetActive(true); //Enable Next Gun
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            weapons[index].gameObject.SetActive(false);
            index = 1;
            weapons[index].gameObject.SetActive(true);
        }


    }


}
