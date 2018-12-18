using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : BaseState {

    public override void UpdateState(Enemy EnimeAI)
    {
        base.UpdateState(EnimeAI);

        RaycastHit hit;
        if (Physics.Raycast(EnimeAI.eye.position, EnimeAI.eye.transform.forward, out hit, EnimeAI.weaponRange))
        {

        }
    }   
}