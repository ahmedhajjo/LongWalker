using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekChase : BaseAI {
   
    public override void UpdateState(SmartMan EnimeAI)
    {
        
        base.UpdateState(EnimeAI);

        Vector3 direction = EnimeAI.playerTransform.position - EnimeAI.transform.position;
        float angle = Vector3.Angle(direction, EnimeAI.transform.forward);

        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) < 20f && angle < 100f)
        {
            direction.y = 0;

            EnimeAI.transform.rotation = Quaternion.Slerp(EnimeAI.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            Seeking(EnimeAI);

        }
        else
            patrol(EnimeAI);

            Attack(EnimeAI);



    }


    public void Seeking(SmartMan EnimeAI)
    {
        Vector3 DesiredVel = EnimeAI.playerTransform.transform.position - EnimeAI.transform.position;
        DesiredVel = Vector3.Normalize(DesiredVel);
        DesiredVel *= 20f;
        Vector3 seekForce = DesiredVel - EnimeAI.rb.velocity;

        EnimeAI.move(seekForce);
  
    }


    public void patrol(SmartMan EnimeAI)
    {
        Vector3 direction = EnimeAI.Waypoints[EnimeAI.current].transform.position - EnimeAI.transform.position;
        float angle = Vector3.Angle(direction, EnimeAI.transform.forward);

        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) > 20f && angle > 100f)
        {

            EnimeAI.CurrentState = new Patrol();
            EnimeAI.move(direction);
            Debug.Log(" i am now patroing");


        }

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
