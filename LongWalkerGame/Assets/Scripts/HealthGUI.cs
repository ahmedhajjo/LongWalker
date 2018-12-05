using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthGUI : MonoBehaviour {


    [SerializeField]private float MinHealth = 1;
    [SerializeField]private float MaxHealth = 100;

    public void RemoveHealth(float amount)

    {
        if (MaxHealth < MinHealth)
        {
            Destroy(this.gameObject);
        }

        else
        {
            MaxHealth -= amount;
        }
        }
    }

