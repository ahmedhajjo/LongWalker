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

    


    //private float switchDelay = 1f;


    

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


      

        if (Input.GetButton("Fire1"))
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
        if (fireTimer < FireRate)
            fireTimer += Time.deltaTime;

    
      
       
	}


    private void Fire()
    {

        AnimatorStateInfo info = anima.GetCurrentAnimatorStateInfo(0);
        isRealoading= info.IsName("Fire");

        if (fireTimer < FireRate || currentBullets <= 0 || isRealoading ) return;

        RaycastHit hit;
        if (Physics.Raycast(shootpoint.position, shootpoint.transform.forward, out hit, weaponRange))
        {
            GameObject SpawnDecal = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
            Debug.Log(hit.transform.name + "found");

            GameObject SpawnHole = Instantiate(HoleEffect, hit.point, Quaternion.FromToRotation(Vector3.forward,hit.normal));

            

            Destroy(SpawnDecal, 0.2f);
            Destroy(SpawnHole, 0.2f);

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






        AnimatorStateInfo info = anima.GetCurrentAnimatorStateInfo(0);
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

    //void Pistol()
    //{
    //    PistolObj.SetActive(true);
    //    ShootGunObj.SetActive(false);AssultObj.SetActive(false);


    //    Damage = 10f;
    //    weaponRange = 50f;
    //    IsActive = false;
    //}

    //void Assult()
    //{
    //    AssultObj.SetActive(true);
    //    PistolObj.SetActive(false);ShootGunObj.SetActive(false);


    //    Damage = 15f;
    //    weaponRange = 70f;
    //    IsActive = true;
    //}

    //void ShootGun()
    //{
    //    ShootGunObj.SetActive(true);
    //    AssultObj.SetActive(false); PistolObj.SetActive(false);
    //    Damage = 20;
    //    weaponRange = 15f;
    //    IsActive = false;
    //}



  

}
