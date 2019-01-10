using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour {

    public Text TimeText;

    public Text HealthText;

    float Minutes, Second;

    float health;

    public Text MagAmmo;
    public Text totalAmmo;

    HealthGUI HealtUI;
    Weapons WeaponScript;
    PlayerController PlayerScript;
    public GameObject Player;


    public WeaponsManager wm;
    GameObject CurrentWeapon;
    // Use this for initialization

    void Start () {
        PlayerScript = Player.GetComponent<PlayerController>();

        
        
    }
	
	// Update is called once per frame
	void Update () {



        //  Move to manager 
        //current weapon make it public 
        for (int i = 0; i < wm.weapons.Length; i++)
        {
            if (wm.weapons[i].activeInHierarchy)
            {
                CurrentWeapon = wm.weapons[i];
                WeaponScript = CurrentWeapon.GetComponent<Weapons>();
            }
        }


        Minutes = (int)(Time.time / 60);
        Second = (int)(Time.time % 60);
        TimeText.text = Minutes.ToString("00") + ":" + Second.ToString("00");

        HealthText.text = "+"+ PlayerScript.PlayerHealth;

        MagAmmo.text = WeaponScript.currentBullets + "";
        totalAmmo.text = WeaponScript.BulletsLeft + "";
	}
}
