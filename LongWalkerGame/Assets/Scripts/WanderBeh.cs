using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderBeh : BaseState {



    public override void UpdateState(Enemy EnimeAI)
    {
        base.UpdateState(EnimeAI);
         EnimeAI.wanderTime += Time.deltaTime;

        if (EnimeAI.wanderTime < EnimeAI.wanderLimit)
        {
            Wander(EnimeAI);

            Debug.Log("IM WANDE223R");
        }

        else
        {
           
            Patrol(EnimeAI);

            Debug.Log("IM WANDE22323R22");
        }


    }


    Vector3 Wander(Enemy EnimeAI)
    {


   EnimeAI.wanderTime += Time.deltaTime;


        
            //Calculate the circle center
            Vector3 circleCenter;
            circleCenter = EnimeAI.rb.velocity;
            circleCenter = Vector3.Normalize(circleCenter);
            circleCenter *= (EnimeAI.circleDistance);
            //Calculate the displacement force
            Vector3 displacement;
            displacement = new Vector3(-1, 0, 0);
            displacement *= EnimeAI.circleRadius;
            //Randomly change the vector direction by making it change its current angle
            displacement = SetAngle(displacement, EnimeAI.wanderAngle);
            //Change wanderAngle just a bit, so it won't have the same value on the next game frame.
            EnimeAI.wanderAngle += (Random.Range(0f, 1f) * EnimeAI.angleChange) - (EnimeAI.angleChange * 0.5f);
            //Finally calculate and return the wander force
            Vector3 wanderForce;
            wanderForce = circleCenter + displacement;
            return wanderForce;
       
        Debug.Log("IM WANDER");
    }




    Vector3 SetAngle(Vector3 vector, float value)
    {
        float len = vector.magnitude;
        vector.x = Mathf.Cos(value) * len;
        vector.z = Mathf.Sin(value) * len;
        return vector;


    }



    public void Patrol(Enemy EnimeAI)
    {

        EnimeAI.wanderTime += Time.deltaTime;

        if (EnimeAI.wanderTime > EnimeAI.wanderLimit)
        {
            EnimeAI.CurrentState = new EnemiesMove();

            Debug.Log(" BackToPatrolWan");

        }
        else
        {
            Wander(EnimeAI);
        }
    }

}
