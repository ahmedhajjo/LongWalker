using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour
{

    public Vector3 aimDown;
    public Camera MainCamera;
    public Vector3 HipFire;
    


    float AimSpeed = 30f;
    float AimedScoop = 55f;
    float NormalVov = 60;
    public bool isAiming;

    public Weapons AKreload,M4r;
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1) &&  !AKreload.info.IsName("Reload"))  //Input MouseButton1   // Disable Realod Animation While Reloading
        {
            transform.localPosition = Vector3.Slerp(transform.localPosition, aimDown, AimSpeed * Time.deltaTime);  
            Debug.Log("AIMING");
            MainCamera.fieldOfView = AimedScoop; //Access to Main Camer FieldOfView  and Change Values 
            isAiming = true;
           
        }

        if (Input.GetMouseButtonUp(1))  //OutPut MouseButton1
        {
            MainCamera.fieldOfView = NormalVov;
            isAiming = false;
            transform.localPosition = HipFire;
            Debug.Log("NOTAIMING");
        }


    }

}
