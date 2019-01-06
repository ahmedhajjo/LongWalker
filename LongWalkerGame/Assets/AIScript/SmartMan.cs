using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartMan : MonoBehaviour {



    // PATROL Values
    public BaseAI CurrentState;

    public Transform[] Waypoints;
    public Transform WpParent;
    public Transform playerTransform;
    public Transform eye;
    public Rigidbody rb;

    public int current = 0;


    //CHASE / SEEK VALUES
    public float MaxForce;
    public float MaxSpeed;

    //  Wander Values;
    //float circleDistance;
    //float circleRadius;
    //float angleChange;
    // float wanderAngle;
    // float wanderTime;
    //float wanderLimit;

    public float RadiusEye;

    //ATTACK Values

    public float WeaponRange;

    //Enemie Valuse

    public int health = 100;

    // Use this for initialization
    void Start () {
       
        rb = GetComponent<Rigidbody>();

        CurrentState = new Patrol();

    }
	
	// Update is called once per frame
	void Update () {
        CurrentState.UpdateState(this);
 
    }


    public void move(Vector3 dir)
    {
  
        rb.AddForce(dir);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, RadiusEye);
    }


    public void TakeDamage()
    {
        health -= 10;
    }

}
