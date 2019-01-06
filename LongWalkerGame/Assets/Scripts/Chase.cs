using UnityEngine;

public class Chase : BaseState {

    float MaxVel = 20;
    public float MaxForce;
    public float MaxSpeed;
    public float SlowRadius;



    public float speed = 10;
   

        public override void UpdateState(Enemy EnimeAI)
        {
            base.UpdateState(EnimeAI);




        Chases(EnimeAI);





        Attack(EnimeAI);

        Wander(EnimeAI);

    }



    public void Attack(Enemy EnimeAI)
    {

        Vector3 direction = EnimeAI.playerTransform.position - EnimeAI.transform.position;
        float angle = Vector3.Angle(direction, EnimeAI.transform.forward);
        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) < 10f )
        {
            EnimeAI.CurrentState = new Attack();

            Debug.Log(" Go To attack");

        }
    }


    public void Chases (Enemy EnimeAI)
    {

        Vector3 direction = EnimeAI.playerTransform.position - EnimeAI.transform.position;
        float angle = Vector3.Angle(direction, EnimeAI.transform.forward);

        if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) < 20f && angle < 100)
        {

            direction.y = 0;

            EnimeAI.transform.rotation = Quaternion.Slerp(EnimeAI.transform.rotation, Quaternion.LookRotation(direction), 0.1f);


            if (direction.magnitude > 3)
            {
                EnimeAI.transform.Translate(0, 0, 0.5f * Time.deltaTime * speed);
            }
        }



    }



    public void Wander(Enemy EnimeAI)
    {
         if (Vector3.Distance(EnimeAI.playerTransform.position, EnimeAI.transform.position) > 20f)
        {
            EnimeAI.CurrentState = new WanderBeh();
        }

    }

    Vector3 Seeking(Enemy EnimeAI)
    {
        Vector3 DesiredVel = EnimeAI.playerTransform.transform.position - EnimeAI.transform.position;
        DesiredVel = Vector3.Normalize(DesiredVel);
        DesiredVel *= MaxVel;
        Vector3 seekForce = DesiredVel - EnimeAI.rb.velocity;

        return seekForce;

    }

}

    
    
     

