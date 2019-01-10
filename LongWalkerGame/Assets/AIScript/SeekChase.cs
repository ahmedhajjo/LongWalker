using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekChase : BaseAI {


    public Patrol patrol;
    public override void UpdateState(SmartMan EnimeAI)
    {


        Debug.Log("Seek");

        Vector3 direction = EnimeAI.playerTransform.position - EnimeAI.transform.position;
        float angle = Vector3.Angle(direction, EnimeAI.transform.forward);

        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) < 2f && angle < 50f)
        {
            Seeking(EnimeAI);
            direction.y = 0; 
            EnimeAI.transform.rotation = Quaternion.Slerp(EnimeAI.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

           

        }
        else
            EnimeAI.CurrentState = new Patrol();


        Debug.Log(Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position));



        Debug.Log(angle);
    }


    public void Seeking(SmartMan EnimeAI)
    {
        Vector3 DesiredVel = EnimeAI.playerTransform.transform.position - EnimeAI.transform.position;
        DesiredVel = Vector3.Normalize(DesiredVel);
        DesiredVel *= EnimeAI.MaxSpeed;
        Vector3 seekForce = DesiredVel - EnimeAI.rb.velocity;

        EnimeAI.move(seekForce);
  
    }


 



    public void Attack(SmartMan EnimeAI)
    {

        Vector3 direction = EnimeAI.playerTransform.position - EnimeAI.transform.position;
        float angle = Vector3.Angle(direction, EnimeAI.transform.forward);
        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) < 0.5f )
        {
            EnimeAI.CurrentState = new AttackBeh();

            Debug.Log(" Go To attack");

        }
    }
}
