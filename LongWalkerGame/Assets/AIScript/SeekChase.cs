using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekChase : BaseAI
{


    public Patrol patrol;
    public float reachedPlayerDistance = 0.5f;


    public override void UpdateState(SmartMan EnimeAI)
    {
        Vector3 direction = EnimeAI.playerTransform.position - EnimeAI.transform.position;
        float angle = Vector3.Angle(direction, EnimeAI.transform.forward);

        //if i am not close enough to player, then i will chase. else attack

 

        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) < reachedPlayerDistance)
        {
            EnimeAI.CurrentState = new AttackBeh(EnimeAI.playerTransform.GetComponent<PlayerController>(), EnimeAI);

        }
        else if(Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) < 3f &&
                Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) > reachedPlayerDistance)
        {

            EnimeAI.anim.SetBool("isRun", true);
            EnimeAI.anim.SetBool("isWalk", false);

            Seeking(EnimeAI);
            direction.y = 0;
            EnimeAI.transform.rotation = Quaternion.Slerp(EnimeAI.transform.rotation, Quaternion.LookRotation(direction), 0.1f);
        }
        else
        {
            EnimeAI.CurrentState = new Patrol(EnimeAI);
        }
    }


    public void Seeking(SmartMan EnimeAI)
    {
        Vector3 DesiredVel = EnimeAI.playerTransform.transform.position - EnimeAI.transform.position;
        DesiredVel = Vector3.Normalize(DesiredVel);
        DesiredVel *= EnimeAI.MaxSpeed;
        Vector3 seekForce = DesiredVel - EnimeAI.rb.velocity;

        EnimeAI.move(seekForce);

    }
}
