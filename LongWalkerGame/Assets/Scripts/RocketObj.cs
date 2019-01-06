using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketObj : MonoBehaviour
{
    public float Radius = 5.0f;
    public float Power = 10.0f;
    public float ExplosiveKick = 1.0f;



    void Start()
    {

        Destroy(gameObject, 3);

    }

    void OnCollisionEnter(Collision collision)
    {

        Vector3 grenadeOrigin = transform.position;

        Collider[] colliders = Physics.OverlapSphere(grenadeOrigin, Radius);

        foreach (Collider hit in colliders)
            

            if (hit.GetComponent<Rigidbody>())
            {

                hit.GetComponent<Rigidbody>().AddExplosionForce(Power, grenadeOrigin, Radius, ExplosiveKick); 
            }

        Destroy(gameObject);   

    }

}