using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : BaseAI {

    public float speed = 2;
    float WPRadius = 0.2f;
    float RotationSpeed;



    int current = 0;

    bool isIdle;
    bool endReached = false;
    

    public override void UpdateState(SmartMan EnimeAI)
    {
        base.UpdateState(EnimeAI);

        Debug.Log("Move");

        if (Vector3.Distance(EnimeAI.transform.position, EnimeAI.Waypoints[current].transform.position) < WPRadius)
        {

            Debug.Log("Move");
            if(endReached == false)
              current++;

            EnimeAI.StartCoroutine(IdleWhenWayPointReached());


            if (current >= EnimeAI.Waypoints.Length)
            {
                current--;
                endReached = true;


            }

            else if (endReached == true)
            {

                if (current == 0)
                    endReached = false;
                else
                  current--;
            }
            
            Debug.Log(current);

        }
        if (!isIdle)
        {
            Debug.Log("IM AI AND IM MOVING");
            Move(EnimeAI);

        }
        
        Chases(EnimeAI);

    }

    
    private IEnumerator IdleWhenWayPointReached()
    {
        // Random Amount of time


     //   float randomTime = Random.Range(3, 5);
        Debug.Log(" STOP MOVING");


        isIdle = true;

        yield return new WaitForSeconds(0.1f);

        isIdle = false;
       
        Debug.Log(" Resume MOVING");

    }




    void Move(SmartMan EnimeAI)
    {
        EnimeAI.transform.position = Vector3.MoveTowards(EnimeAI.transform.position, EnimeAI.Waypoints[current].transform.position, Time.deltaTime * speed);
        Vector3 reachPosition = EnimeAI.Waypoints[current].transform.position;
        reachPosition.y = EnimeAI.transform.position.y;
        EnimeAI.transform.rotation = Quaternion.Slerp(EnimeAI.transform.rotation, Quaternion.LookRotation(reachPosition - EnimeAI.transform.position), 0.1f);


        
    }

    
    public void Chases(SmartMan EnimeAI)
    {

        Vector3 direction = EnimeAI.playerTransform.position - EnimeAI.transform.position;
        float angle = Vector3.Angle(direction, EnimeAI.transform.forward);

        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) < 1   && angle < 100)
        {

            EnimeAI.CurrentState = new SeekChase();

            Debug.Log(" I am now chasing");
        }

    }
}
