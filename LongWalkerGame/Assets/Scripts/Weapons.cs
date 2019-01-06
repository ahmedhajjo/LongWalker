using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

    public int BulletsMag;       
    public int BulletsLeft;
    public int currentBullets;

    public float Damage;
    public float weaponRange;


    private bool IsActive;
    bool isRealoading;

    public Transform shootpoint;

    public float FireRate = 0.1f;

    public float fireTimer;
  

    private Animator anima;

    public ParticleSystem flash;

    public GameObject effect;
    public GameObject HoleEffect;
    public AudioSource Audio;
    public AudioClip shootSound;

    AnimatorStateInfo info;
  
    public Weapons[] weapons;
    public int index;

  



    ////public AudioSource AkSound, PistolSound;
    ////public ParticleSystem PistolFire, PistolBullet, AkFire, AkBullet;




    // Use this for initialization
    void Start()
    {
        anima = GetComponentInParent<Animator>();
        Audio = GetComponentInParent<AudioSource>();

        
        currentBullets = BulletsMag;


       

    }
	
 

	// Update is called once per frame
	void Update () {
        info = anima.GetCurrentAnimatorStateInfo(0);
        SwipGuns();
        if (Input.GetButton("Fire1") && !info.IsName("Reload"))
        {
            if (currentBullets > 0)
                Fire();

            else 
                    Reload();   

        }

        if (Input.GetKeyDown(KeyCode.R))
            
        {
            if (currentBullets < BulletsMag)
            {   
            Reload();
            }

        
           
        }
        if (fireTimer < FireRate) fireTimer += Time.deltaTime;

          
        /* if ((Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3)) && !info.IsName("Reload"))
         {

             Debug.Log("firon");

             isRealoading = info.IsName("GunIn");
             anima.CrossFadeInFixedTime("GunIn", 1f);
         }
         */


        


    }


    private void Fire()
    {

        isRealoading = info.IsName("Fire");

        if (fireTimer < FireRate || currentBullets <= 0 || isRealoading ) return;

        RaycastHit hit;
        if (Physics.Raycast(shootpoint.position, shootpoint.transform.forward, out hit, weaponRange))
        {
            GameObject SpawnDecal = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
            SpawnDecal.transform.SetParent(hit.transform);

            Debug.Log(hit.transform.name + "found");

            GameObject SpawnHole = Instantiate(HoleEffect, hit.point, Quaternion.FromToRotation(Vector3.forward,hit.normal));
            SpawnHole.transform.SetParent(hit.transform);


            Destroy(SpawnDecal, 1f);
            Destroy(SpawnHole, 2f);

            if(hit.transform.GetComponent<HealthGUI>())
            {
                hit.transform.GetComponent<HealthGUI>().RemoveHealth(Damage);
            }

            if (hit.transform.GetComponent<PlayerController>())
            {
                hit.transform.GetComponent<HealthGUI>().RemoveHealth(Damage);
            }

                

        }



        anima.CrossFadeInFixedTime("Fire", 0.01f);
            flash.Play();
           
        currentBullets--;
        fireTimer = 0.0f; //Reset Fire Timer 

        Audio.PlayOneShot(shootSound);

      
       
    }

    private void Reload()
    {
        if (BulletsLeft <= 0) return;

        int bulletLoad = BulletsMag - currentBullets;
        int BulletDeduct = (BulletsLeft >= bulletLoad) ? bulletLoad : BulletsLeft;

        BulletsLeft -= BulletDeduct;
        currentBullets += BulletDeduct;

        isRealoading = info.IsName("Reload");

        if (isRealoading) {return; }

        //--->
        anima.CrossFadeInFixedTime("Reload", 0.5f);

     

    }



    //private IEnumerator SwitchDelay(int NewIndex)
    //{

    //    IsActive = true;
    //    yield return new WaitForSeconds(switchDelay);

    //    IsActive = false;
    //    SwitchGuns();

    //}


    public void SwipGuns() {


        isRealoading = info.IsName("GunIn");

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {

            weapons[index].gameObject.SetActive(false);
            index = 0;
            weapons[index].gameObject.SetActive(true);
            anima.CrossFadeInFixedTime("GunOut", 0.5f);

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
    
            weapons[index].gameObject.SetActive(false);
            index = 1;
            weapons[index].gameObject.SetActive(true);
            anima.CrossFadeInFixedTime("GunOut", 0.5f);

        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            weapons[index].gameObject.SetActive(false);
            index = 2;
            weapons[index].gameObject.SetActive(true);
        }
    }
    
   
  }


