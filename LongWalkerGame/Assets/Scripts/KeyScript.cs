using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyScript : MonoBehaviour {

    [SerializeField] GameObject PressEText;
    [SerializeField] DoorScript OpenDoor;
    [SerializeField] DoorScript closeDoor;
    [SerializeField] SpawnManager SM;
    [SerializeField] EndGame EG;
    [SerializeField] AudioClip EnableClip;
    private bool isNear = false;

    private void OnTriggerEnter(Collider other)    //EnterTrigger
    {
        isNear = true;   //Enable 
        PressEText.SetActive(true);  //Enable text Active
    }

    private void OnTriggerExit(Collider other)       //Exit Trigger
    {
        isNear = false;
        PressEText.SetActive(false);
    }

    private void Update()
    {
        if (isNear && Input.GetKey(KeyCode.E))
        {
            
            EG.CanEnd = true;
            SM.StartSpawn = true;
            OpenDoor.Access = true;
            closeDoor.Access = false;
            GameObject.Destroy(gameObject);
            PressEText.SetActive(false);
        }
    }



}
