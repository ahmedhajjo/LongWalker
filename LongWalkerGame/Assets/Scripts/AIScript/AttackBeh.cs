using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBeh : BaseAI
{

 
    public float Damage = 10;
    bool IsAttacking;

    public AttackBeh(PlayerController player, SmartMan EnimeAI)
    {
        IsAttacking = true;
        EnimeAI.StartCoroutine(Attack(player, EnimeAI));
        EnimeAI.anim.SetBool("isRun", false);
        
    }

    public override void UpdateState(SmartMan EnimeAI)
    {

        Vector3 direction = EnimeAI.playerTransform.position - EnimeAI.transform.position;
        direction.y = 0;
        EnimeAI.transform.rotation = Quaternion.Slerp(EnimeAI.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

        //if the enemy is too far for attack (0.4 meter) BUT not more than 4 meter, chase the player 
        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) < 2f &&
             Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) > 0.4f)
        {
            EnimeAI.CurrentState = new SeekChase();

            IsAttacking = false;
        }

         //if the enemy is far away more than 2 meter, go back to patrol
        else if(Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) > 2f )
        {
            EnimeAI.CurrentState = new Patrol(EnimeAI);
        }
    }

    IEnumerator Attack(PlayerController player, SmartMan EnimeAI)
    {   while (IsAttacking)

        {
            EnimeAI.anim.SetTrigger("Attack");
            player.GetComponent<PlayerController>().ApplyDamage((int)Damage);
            yield return new WaitForSeconds(4f);
        } 




    }

}


