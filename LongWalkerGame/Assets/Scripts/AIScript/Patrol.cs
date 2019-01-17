using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : BaseAI
{
    int current;      //Current WP
    bool isIdle;       
    bool endReached = false;
    

    public Patrol(SmartMan EnimeAI)    //Constructor that starts at beginning of Class
    {
        EnimeAI.anim.SetBool("isRun", false);
        Closest(EnimeAI);
    }

    public override void UpdateState(SmartMan EnimeAI) //OverRidded From BaseAI
    {
        Debug.Log("Move");
        if (Vector3.Distance(EnimeAI.transform.position, EnimeAI.Waypoints[current].transform.position) < EnimeAI.WPRadius) // Condition Between Enemy and Waypoints is greater than WayPoint Raduius.
        {

            Debug.Log("Move");
            if (endReached == false)  //Move next Wp
                current++;

            EnimeAI.StartCoroutine(IdleWhenWayPointReached(EnimeAI));  //IEnumrator Starts For IDLE at waypoint

            if (current >= EnimeAI.Waypoints.Length) // if CurrentWp is  larger equal to Waypoints go back to //EndReached to last WP
            {
                current--;
                endReached = true;


            }

            else if (endReached == true) //Condition EndReached is false so the cuurent is firstway Point else go back to Current 0 
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
            Move(EnimeAI); // IF not Is Idle Move 

            EnimeAI.anim.SetBool("isWalk", true); //Play Animation
            

        }


       
        

        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) < 2f ||EnimeAI.Alerted==true)  //Condition To Seek Class  Position Between Player and Enemy
            {
            EnimeAI.CurrentState = new SeekChase(); 
        }
    }


    private IEnumerator IdleWhenWayPointReached(SmartMan EnimeAI) //IEnumerator on For Idle Make the Enemy Idle on reach eachWaypoint with random Range Time.
    {
        // Random Amount of time


        float randomTime = Random.Range(3, 5); //Random Range
        Debug.Log(" STOP MOVING");



        isIdle = true;  
        EnimeAI.anim.SetBool("isWalk", false); //Idle Animation
       yield return new WaitForSeconds(randomTime);  //Stops for Seconds
        isIdle = false; // Resume Move
        Debug.Log(" Resume MOVING");
    }




    void Move(SmartMan EnimeAI)  // Enemy Movement
    {
        //VectorMoveTowards  (Vector Current , Vector Target , Float MaxDelta
        EnimeAI.transform.position = Vector3.MoveTowards(EnimeAI.transform.position, EnimeAI.Waypoints[current].transform.position, Time.deltaTime * EnimeAI.speed);  
        Vector3 reachPosition = EnimeAI.Waypoints[current].transform.position;  //Vector Positon Current Waypoint
        reachPosition.y = EnimeAI.transform.position.y; //ReachPosition Uses Y position Only.
        EnimeAI.transform.rotation = Quaternion.Slerp(EnimeAI.transform.rotation, Quaternion.LookRotation(reachPosition - EnimeAI.transform.position), 0.1f);  //Enemy Rotation To look at WayPoint.
    }


    public void Closest(SmartMan EnimeAI) // Go To Closest WayPoint After Chase
    {


        int index = -1;
        float TempDis = Mathf.Infinity; //Infinity Number
        for (int i = 0; i < EnimeAI.Waypoints.Length; i++) //Forloop How ManyWaypoints Available.
        {
            float Dis = Vector3.Distance(EnimeAI.transform.position, EnimeAI.Waypoints[i].transform.position); //Vector Distance Between Enemy and Waypoint CurrentOne

            if (Dis < TempDis) // Distane < Temporary Dis , So find the closest Current Waypoint
            {
                TempDis = Dis;
                index = i;
            }
        }

        current = index; //Current Waypoint is equal To Closest Index.


    }


}
