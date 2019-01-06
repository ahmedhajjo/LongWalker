using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketPla : MonoBehaviour
{

    public Rigidbody rocketReal;
    public GameObject clone;
    public ParticleSystem roocket;
    public float ThrowPower = 10; 

    public void Update()
    {

        Rigidbody clone;



        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Shooting");
            clone = Instantiate(rocketReal, transform.position, transform.rotation);


            clone.velocity = transform.TransformDirection(Vector3.forward * ThrowPower);
        }
    }
}