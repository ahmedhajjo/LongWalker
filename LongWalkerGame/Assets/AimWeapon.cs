using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimWeapon : MonoBehaviour {

    public Vector3 aimDown;

    public Camera MainCamera;

    public Vector3 HipFire;

    public Animator anim;


    float AimSpeed = 30f;
    float AimedScoop = 55f;
    float NormalVov = 60;

    // -0.046     -3.13    -0.162

    //-0.31     -3.151     -0.183


    //-0.791
    // Update is called once per frame
    void Update () {
		if (Input.GetMouseButton(1))
        {

    
            transform.localPosition = Vector3.Slerp(transform.localPosition,aimDown,AimSpeed* Time.deltaTime);
           

            Debug.Log("AIMING");

            MainCamera.fieldOfView = AimedScoop;
            anim.SetBool("IsAim", false);

        }

        if (Input.GetMouseButtonUp(1))
        {
            MainCamera.fieldOfView = NormalVov;
            anim.SetBool("IsAim",true);

            transform.localPosition = HipFire;

            Debug.Log("NOTAIMING");
        }


	}

}
