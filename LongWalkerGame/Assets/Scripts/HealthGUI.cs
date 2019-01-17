using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGUI : MonoBehaviour {


    [SerializeField]private float MinHealth = 1; 
    public float MaxHealth = 100;                          //FLoat Health

    public void RemoveHealth(float amount)  //Removal Health

    {
        if (MaxHealth < MinHealth)
        {
           
        }

        else
        {
            MaxHealth -= amount;
        }
        }
    }

