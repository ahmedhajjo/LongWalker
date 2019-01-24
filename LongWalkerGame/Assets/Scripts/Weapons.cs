using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour
{

    [SerializeField] int BulletsMag;    // Size of Magizine    
    public int BulletsLeft;   //Bullets Left Of Total
    public int currentBullets; //Current OF Bullets

    [SerializeField] int Damage; //Int Damage

    [SerializeField] float weaponRange; //Weapon Range

    [SerializeField] float FireRate;
    [SerializeField] float fireTimer;


    //Game Objects
    public Transform shootpoint;
    public GameObject BloodEffect;
    public GameObject effect;
    public GameObject HoleEffect;
    

    //Audio
    public AudioSource Audio;
    public AudioClip shootSound;
    //Animation & ParticleSystem
    public AnimatorStateInfo info;
    private Animator anima;
    public ParticleSystem flash;
    bool isRealoading;




    // Use this for initialization
    void Start()
    {
        anima = GetComponentInParent<Animator>();
        Audio = GetComponentInParent<AudioSource>();
        currentBullets = BulletsMag;






    }



    // Update is called once per frame
    void Update()
    {
        
        info = anima.GetCurrentAnimatorStateInfo(0); //Animation Idle

        if (Input.GetButton("Fire1") && !info.IsName("Reload")) //Fire Pressed Player Animation Fire and Disable Realod Animation
        {
            if (currentBullets > 0) //If Current is larger than 0 Fire Can work , else reload.
                Fire();

            else
                Reload();

        }

        if (Input.GetKeyDown(KeyCode.R)) //Press R To reload but only if Current less than Size Of Magazine

        {
            
            if (currentBullets < BulletsMag)
            {
                Reload();
            }



        }
        if (fireTimer < FireRate) fireTimer = Time.deltaTime; //if FireRate is bigger than Fire Timer Play Fire Timer.
    }


    private void Fire() //Fire Function 
    {

        isRealoading = info.IsName("Fire");  //Fire Animation

        if (fireTimer < FireRate || currentBullets <= 0 || isRealoading) return;  //

        RaycastHit hit;

      
        if (Physics.Raycast(shootpoint.position, shootpoint.transform.forward, out hit, weaponRange)) //RayCast (Vector Origin, Vector Direction ,FloatMaxDistance)
        {
            
            GameObject SpawnDecal = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));  //Istantiate Effect GameObject 
            SpawnDecal.transform.SetParent(hit.transform);

            Debug.Log(hit.transform.name + "found");
            GameObject SpawnHole;
            if (hit.collider.tag == "Enemy")
            {
                SpawnHole = Instantiate(BloodEffect, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)); //Istantiate Effect GameObject 

            }
            else
            {

                SpawnHole = Instantiate(HoleEffect, hit.point, Quaternion.FromToRotation(Vector3.forward, hit.normal)); //Istantiate Effect GameObject 

            }


            Destroy(SpawnDecal, 1f);
            Destroy(SpawnHole, 2f);         //Destroy Hole, Decal

            if (hit.transform.GetComponent<HealthGUI>()) //Damage Health
            {
                hit.transform.GetComponent<HealthGUI>().RemoveHealth(Damage);
            }


            // Damage Smartman
            if (hit.transform.GetComponent<SmartMan>())
            {
                hit.transform.GetComponent<SmartMan>().ApplyDamage(Damage);
            }
        }

        // 
        anima.CrossFadeInFixedTime("Fire", 0.01f);  //Fades the animation with name animation in over a period of time seconds and fades other animations out.
        flash.Play();  //Play ParticleSystem

        currentBullets--; //Deduct Bullet
        fireTimer = 0.0f; //Reset Fire Timer 

        Audio.PlayOneShot(shootSound); //PLay Sound OF audioClip
    }

    private void Reload()      //Reload Function
    {

        if (BulletsLeft <= 0) return;   //BulletLeft is less than 0 Make A Return

        int bulletLoad = BulletsMag - currentBullets; //Bullet Load is Size OF MAG - CURRENT BULLETS
        int BulletDeduct = (BulletsLeft >= bulletLoad) ? bulletLoad : BulletsLeft;    //Ternany Operator is Bulletload or BulletLeft

        BulletsLeft -= BulletDeduct;
        currentBullets += BulletDeduct;


        isRealoading = info.IsName("Reload");  //Play Animation Realoding

       if (isRealoading ) { return; }

        anima.CrossFadeInFixedTime("Reload", 0.1f); //Fades the animation with name animation in over a period of time seconds and fades other animations out.



    }


}


