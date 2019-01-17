using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmartMan : MonoBehaviour
{



    // PATROL Values
    public BaseAI CurrentState;

    public Transform[] Waypoints;

    public Transform playerTransform;
    public Transform eye;
    public Rigidbody rb;

    GameObject[] WaypointsComponenet;
    WP_Parent WP_ParentScript;


    public Animator anim;

    public int current = 0;

    public float speed = 1;
    public float WPRadius = 0.2f;

    //CHASE / SEEK VALUES
    public float MaxForce;
    public float MaxSpeed;



    public float RadiusEye;

    //ATTACK Values


    public bool Alerted = false;
    public float lastAlerted = 0;

    //Enemie Valuse

    public int health = 100;



    // Use this for initialization
    void Start()
    {
        FindGameObjects();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        CurrentState = new Patrol(this);



    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(CurrentState.GetType());
        CurrentState.UpdateState(this);

        if (health <= 0)
        {
            enabled = false;

            GetComponent<CapsuleCollider>().enabled = false;
            rb.isKinematic = true;


            anim.SetTrigger("isDeath");
            Destroy(gameObject, 5f);
        }

        if (Alerted == true && lastAlerted < Time.time)
        {
            Alerted = false;
        }


        RaycastHit hit;
        if (Physics.Raycast(eye.position, eye.transform.forward, out hit, 1.1f) && hit.collider.CompareTag("Enemy"))
        {
            transform.Rotate(0, 10, 0);
        }

    }


    public void move(Vector3 dir)
    {
        rb.AddForce(dir * MaxForce);
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, MaxSpeed);
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, RadiusEye);
    }



    public void ApplyDamage(int Dmg)
    {
        health = health - Dmg;
        Alerted = true;
        lastAlerted = Time.time + 5;
    }

    public void FindGameObjects()
    {

        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        WP_ParentScript = GameObject.FindGameObjectWithTag("Waypoint").GetComponent<WP_Parent>();
        WaypointsComponenet = WP_ParentScript.Waypoints;
        for (int i = 0; i < Waypoints.Length; i++)
        {
            Waypoints[i] = WaypointsComponenet[i].GetComponent<Transform>();
        }

    }




}

