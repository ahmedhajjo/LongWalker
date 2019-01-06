using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SteeringBehaviour : MonoBehaviour {

    float MaxVel = 20;
    public float MaxForce;
    public float MaxSpeed;
    public float SlowRadius;

    GameObject target;
    public Vector3 steering;

    Rigidbody rb;

    
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player");

	}
	
	// Update is called once per frame
	void Update () {

        steering = Arrival();

        steering = Vector3.ClampMagnitude(steering, MaxForce);
        rb.AddForce(steering);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);
		
	}

    Vector3 Seeking()
    {
        Vector3 DesiredVel = target.transform.position - transform.position;
        DesiredVel = Vector3.Normalize(DesiredVel);
        DesiredVel *= MaxVel;
        Vector3 seekForce = DesiredVel - rb.velocity;

        return seekForce;

    }

    Vector3 Flee()
    {

        Vector3 DesiredVel = transform.position - target.transform.position;
        DesiredVel = Vector3.Normalize(DesiredVel);
        DesiredVel *= MaxVel;
        Vector3 fleeForce = DesiredVel - rb.velocity;
        return fleeForce;



    }

    
    
    Vector3 Arrival()

    {

 
        
        //Calculate DesireVel 
        Vector3 DesiredVel = target.transform.position - transform.position;
        float angle = Vector3.Angle(DesiredVel, transform.forward);

        float distance = DesiredVel.magnitude;

        // Checks the if it enters the slow Radius
        if (Vector3.Distance(target.transform.position , transform.position) < 20f && angle < 100)
        {
            DesiredVel.y = 0;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(DesiredVel), 0.1f);

            //is inside Slow area
            if (distance < SlowRadius)
            {
              

                DesiredVel = Vector3.Normalize(DesiredVel) * MaxVel * (distance / SlowRadius);

            }


            //Outside of slowing area
            else
            {
               
                DesiredVel = Vector3.Normalize(DesiredVel) * MaxVel;
            }

        }
       
        // Set the steering based on this
        Vector3 ArrivalForce = DesiredVel - rb.velocity;

        return ArrivalForce;

    }
    
}
