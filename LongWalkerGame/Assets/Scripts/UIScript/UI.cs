using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UI : MonoBehaviour {

    public Text TimeText;

    public Text HealthText;

    float Minutes, Second;

    float health;

	// Use this for initialization
	void Start () {

        TimeText = GetComponent <Text>() ;
       

    }
	
	// Update is called once per frame
	void Update () {

        Minutes = (int)(Time.time / 60);
        Second = (int)(Time.time % 60);
        TimeText.text = Minutes.ToString("00") + ":" + Second.ToString("00");

        HealthText.text = health.ToString("Health") + ":" + "100";
      
	}
}
