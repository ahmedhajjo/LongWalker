using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flee : BaseAI {

    public override void UpdateState(SmartMan EnimeAI)
    {
        base.UpdateState(EnimeAI);

        if (EnimeAI.health <=20)
        {
            FleeB(EnimeAI);
            Debug.Log("flee");
        }
        
    }

        

    public void FleeB(SmartMan EnimeAI)
    {
        Vector3 DesiredVel = EnimeAI.transform.position - EnimeAI.playerTransform.transform.position;
        DesiredVel = Vector3.Normalize(DesiredVel);
        DesiredVel *= 20f;
        Vector3 FleeForce = DesiredVel - EnimeAI.rb.velocity;

        EnimeAI.move(FleeForce);

    }
}
