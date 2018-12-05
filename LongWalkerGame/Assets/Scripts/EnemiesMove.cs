using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMove : MonoBehaviour {


    public float speed;
    float WPRadius = 1;
    float RotationSpeed;

    int current = 0;
    

    public Transform[] Waypoints;
    public Transform WpParent;
    

    void Start()
    {
        GetWP();
       
        
    }

    void Update () {
        if (Vector3.Distance(transform.position, Waypoints[current].transform.position.normalized) < WPRadius)
        {
            current++;
            if (current >= Waypoints.Length)
            {
                current = 0;
            }

           
        }

        Move();
		
	}

    void GetWP()

    {
        int NumbWP = WpParent.childCount;

        Waypoints = new Transform[NumbWP];

        for (int i = 0; i<Waypoints.Length; i++)
        {
            Waypoints[i] = WpParent.GetChild(i);
        }
    }

     void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, Waypoints[current].transform.position, Time.deltaTime * speed).normalized;
        transform.position = new Vector3(transform.position.x, 1.2f, transform.position.z);
    }
}
