using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBeh : BaseAI {


    public float speed = 10;
    public float Damage = 15f;

    public override void UpdateState(SmartMan EnimeAI)
    {
        base.UpdateState(EnimeAI);

        RaycastHit hit;

        //Debug.DrawRay(EnimeAI.eye.position, EnimeAI.eye.forward.normalized * EnimeAI.weaponRange, Color.red);
   


        if (Physics.Raycast(EnimeAI.eye.position, EnimeAI.eye.transform.forward, out hit, EnimeAI.WeaponRange) && hit.collider.CompareTag("Player"))
        {
            Debug.Log("HITCOLID");
            if (hit.transform.GetComponent<PlayerController>())
            {

                // hit.transform.GetComponent<HealthGUI>().RemoveHealth(Damage);


            }
        }
        else chases(EnimeAI);
    }


    public void chases(SmartMan EnimeAI)
    {

        Vector3 direction = EnimeAI.playerTransform.position - EnimeAI.transform.position;
        float angle = Vector3.Angle(direction, EnimeAI.transform.forward);

        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) > 15f && angle < 100f)
        {

            EnimeAI.CurrentState = new SeekChase();

            Debug.Log(" Back to chase");
        }

    }

}
