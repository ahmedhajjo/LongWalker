using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {

    patrol , chase

};

public class EnemenyFSM : MonoBehaviour
{

   
    public Transform playerTransform;
    public float speed;
    public float viewDistance;

    public EnemyState enemyState;


    // patrol
    float WPRadius = 1;
    float RotationSpeed;

    int current = 0;
    bool isIdle;


    public Transform[] Waypoints;
    public Transform WpParent;

    void Start()
    {
        GetWP();


    }




    void Update()
    {

        Vector3 direction = playerTransform.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(playerTransform.position, this.transform.position) < viewDistance && angle < 100)
        {
            enemyState = EnemyState.chase;
        }

        else
            enemyState = EnemyState.patrol;



        switch (enemyState)
        {
            case EnemyState.patrol:
                Patrol();
                break;

            case EnemyState.chase:
                Chase();
                break;
        }
       

    }


    void Patrol()
    {

        if (Vector3.Distance(transform.position, Waypoints[current].transform.position) < WPRadius)
        {
            current++;
            StartCoroutine(IdleWhenWayPointReached());
            if (current >= Waypoints.Length)
            {
                current = 0;
            }


        }


        if (!isIdle)
        {
            Debug.Log("IM AI AND IM MOVING");
            Move();

        }
    }


    void Chase()
    {
        Vector3 direction = playerTransform.position - this.transform.position;
        float angle = Vector3.Angle(direction, this.transform.forward);

        if (Vector3.Distance(playerTransform.position, this.transform.position) < viewDistance && angle < 100)
        {

            direction.y = 0;

            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);


            if (direction.magnitude > 3)
            {
                this.transform.Translate(0, 0, 0.5f * Time.deltaTime * speed);


            }
        }
    }


    private IEnumerator IdleWhenWayPointReached()
    {
        // Random Amount of time


        float randomTime = Random.Range(5, 7);
        Debug.Log(" STOP MOVING");


        isIdle = true;

        yield return new WaitForSeconds(randomTime);

        isIdle = false;
        Debug.Log(" Resume MOVING");

    }

    void GetWP()

    {
        int NumbWP = WpParent.childCount;

        Waypoints = new Transform[NumbWP];

        for (int i = 0; i < Waypoints.Length; i++)
        {
            Waypoints[i] = WpParent.GetChild(i);
        }
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[current].transform.position, Time.deltaTime * speed);
        transform.position = new Vector3(transform.position.x, 1.2f, transform.position.z);
    }


}