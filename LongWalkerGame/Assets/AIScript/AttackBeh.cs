using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBeh : BaseAI
{
    public float speed = 10;
    public float Damage = 15f;
    bool IsAttacking;

    public AttackBeh(PlayerController player, SmartMan EnimeAI)
    {
        Vector3 direction = EnimeAI.playerTransform.position - EnimeAI.transform.position;
        direction.y = 0;
        EnimeAI.transform.rotation = Quaternion.Slerp(EnimeAI.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

        IsAttacking = true;
        EnimeAI.StartCoroutine(Attack(player, EnimeAI));
        EnimeAI.anim.SetBool("isRun", false);
        
    }

    public override void UpdateState(SmartMan EnimeAI)
    {

        //if the enemy is too far for attack (1 meter) BUT not more than 4 meter, chase the player 
        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) < 3f &&
             Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) > 0.5f)
        {
            EnimeAI.CurrentState = new SeekChase();

            IsAttacking = false;
        }

         //if the enemy is far away more than 3 meter, go back to patrol
        else if(Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) > 3f)
        {
            EnimeAI.CurrentState = new Patrol(EnimeAI);
        }
    }

    IEnumerator Attack(PlayerController player, SmartMan EnimeAI)
    {   while (IsAttacking)

        {

            EnimeAI.anim.SetTrigger("Attack");
            yield return new WaitForSeconds(2f);
      

            //player.GetComponent<HealthGUI>().RemoveHealth(Damage);

        } 




    }

}


