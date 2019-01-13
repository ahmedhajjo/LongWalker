using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsManager : MonoBehaviour {



    public GameObject[] weapons;
    public int index;
	
	// Update is called once per frame
	void Update () {

        SwipGuns();

	}


    public void SwipGuns()
    {
        //isRealoading = info.IsName("GunIn");

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


}
