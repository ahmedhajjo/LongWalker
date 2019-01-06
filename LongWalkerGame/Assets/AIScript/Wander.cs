//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Wander : BaseAI{


//    public override void UpdateState(SmartMan EnimeAI)
//    {
//        base.UpdateState(EnimeAI);
   



//        //EnimeAI.wanderTime += Time.deltaTime;
//        //if (EnimeAI.wanderTime > EnimeAI.wanderLimit)
//        //{
//        //    Patrol(EnimeAI);
//        //}
//        //else
//        //{
//        //    Wandering(EnimeAI);
//        //}

//        //Chases(EnimeAI);
//    }



//    //Function that returns a wander force
//   public void Wandering(SmartMan EnimeAI)
//    {
//        //Calculate the circle center
//        Vector3 circleCenter;
//        circleCenter = EnimeAI.transform.position;
//        circleCenter = Vector3.Normalize(circleCenter);
//        circleCenter *= (EnimeAI.circleDistance);
//        // for example the first line


//        //Calculate the displacement force
//        Vector3 displacement;
//        displacement = new Vector3(-1, 0, 0);
//        displacement *= EnimeAI.circleRadius;


//        //Randomly change the vector direction by making it change its current angle
//        displacement = SetAngle(displacement, EnimeAI.wanderAngle);
//        //Change wanderAngle just a bit, so it won't have the same value on the next game frame.
//       EnimeAI.wanderAngle += (Random.Range(0f, 1f) * EnimeAI.angleChange) - (EnimeAI.angleChange * 0.5f);
//        //Finally calculate and return the wander force
//        Vector3 wanderForce;
//        wanderForce = circleCenter + displacement;
//        EnimeAI.move(wanderForce);
//        // 

//        EnimeAI.transform.forward = wanderForce;
//    }

//    Vector3 SetAngle(Vector3 vector, float value)
//    {
//        float len = vector.magnitude;
//        vector.x = Mathf.Cos(value) * len;
//        vector.z = Mathf.Sin(value) * len;
//        return vector;
//    }



//    public void Patrol(SmartMan EnimeAI)
//    {
//        Vector3 direction = EnimeAI.Waypoints[EnimeAI.current].transform.position - EnimeAI.transform.position;
//        float angle = Vector3.Angle(direction, EnimeAI.transform.forward);

//        EnimeAI.wanderTime += Time.deltaTime;
//        if (EnimeAI.wanderTime > EnimeAI.wanderLimit)
//        {

//            EnimeAI.CurrentState = new Patrol();
//            EnimeAI.move(direction);
//            Debug.Log(" I am now patroling");


//        }

//    }

//    public void Chases(SmartMan EnimeAI)
//    {

//        Vector3 direction = EnimeAI.playerTransform.position - EnimeAI.transform.position;
//        float angle = Vector3.Angle(direction, EnimeAI.transform.forward);

//        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) < 20f && angle < 100)
//        {

//            EnimeAI.CurrentState = new SeekChase();

//            Debug.Log(" I am now chasing");
//        }

//    }


 


//}
