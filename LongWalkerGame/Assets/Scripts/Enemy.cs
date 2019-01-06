using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

    public BaseState CurrentState;

    public Transform[] Waypoints;
    public Transform WpParent;
    public Transform playerTransform;


    public Rigidbody rb;


    public Transform eye;
    public float Damage;
    public float weaponRange;

    public float Health;



    //wandER VALUES


    public float wanderAngle;

    public float wanderTime;
    public float wanderLimit;

    public float RadiusEye;
    public float circleDistance;
    public float circleRadius;
    public float angleChange;

    Vector3 steering;
    public float maxForce;
    public float maxSpeed;
    // Use this for initialization
    void Start () {

     

        CurrentState = new EnemiesMove() ;

        Debug.Log("Moving");

        wanderTime = wanderLimit;
        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        CurrentState.UpdateState(this);

        //Prevent force from exceeding a limit, defined in the inspector
        steering = Vector3.ClampMagnitude(steering, maxForce);
        rb.AddForce(steering);
        //Prevent velocity from exceeding a limit, defined in the inspector
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);
    }





    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawSphere(transform.position, RadiusEye);   
    }





}
