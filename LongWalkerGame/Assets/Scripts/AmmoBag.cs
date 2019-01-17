using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoBag : MonoBehaviour {

    public WeaponsManager WM;
    Weapons WeaponScript;
    public int AmmoToAdd = 20;

	void Start () {
        WeaponScript = WM.weapons[WM.index].GetComponent<Weapons>();

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            WeaponScript.BulletsLeft += AmmoToAdd;
            Destroy(gameObject);
        }
    }
}
