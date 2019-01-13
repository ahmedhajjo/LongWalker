using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : BaseAI
{
    int current;
    bool isIdle;
    bool endReached = false;

    public Patrol(SmartMan EnimeAI)
    {
        EnimeAI.anim.SetBool("isRun", false);
        Closest(EnimeAI);
    }

    public override void UpdateState(SmartMan EnimeAI)
    {
        Debug.Log("Move");
        if (Vector3.Distance(EnimeAI.transform.position, EnimeAI.Waypoints[current].transform.position) < EnimeAI.WPRadius)
        {

            Debug.Log("Move");
            if (endReached == false)
                current++;

            EnimeAI.StartCoroutine(IdleWhenWayPointReached(EnimeAI));

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

            EnimeAI.anim.SetBool("isWalk", true);
            

        }


        Vector3 Dir = EnimeAI.playerTransform.position - EnimeAI.transform.position;


        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) < 2f)
            {
            EnimeAI.CurrentState = new SeekChase();
        }
    }


    private IEnumerator IdleWhenWayPointReached(SmartMan EnimeAI)
    {
        // Random Amount of time


        float randomTime = Random.Range(3, 5);
        Debug.Log(" STOP MOVING");



        isIdle = true;
        EnimeAI.anim.SetBool("isWalk", false);

       yield return new WaitForSeconds(randomTime);


        isIdle = false;


        Debug.Log(" Resume MOVING");

    }




    void Move(SmartMan EnimeAI)
    {
        EnimeAI.transform.position = Vector3.MoveTowards(EnimeAI.transform.position, EnimeAI.Waypoints[current].transform.position, Time.deltaTime * EnimeAI.speed);
        Vector3 reachPosition = EnimeAI.Waypoints[current].transform.position;
        reachPosition.y = EnimeAI.transform.position.y;
        EnimeAI.transform.rotation = Quaternion.Slerp(EnimeAI.transform.rotation, Quaternion.LookRotation(reachPosition - EnimeAI.transform.position), 0.1f);

    }


    public void Closest(SmartMan EnimeAI)
    {


        int index = -1;
        float TempDis = Mathf.Infinity;
        for (int i = 0; i < EnimeAI.Waypoints.Length; i++)
        {
            float Dis = Vector3.Distance(EnimeAI.transform.position, EnimeAI.Waypoints[i].transform.position);

            if (Dis < TempDis)
            {
                TempDis = Dis;
                index = i;
            }
        }

        current = index;


    }


}
