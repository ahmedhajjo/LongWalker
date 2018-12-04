using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

    int BulletsMag = 30;       
    public int BulletsLeft = 200;
    public int currentBullets;


    public float weaponRange = 100f;

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

    //public GameObject PistolObj, AssultObj;

    ////public AudioSource AkSound, PistolSound;
    ////public ParticleSystem PistolFire, PistolBullet, AkFire, AkBullet;


 

    // Use this for initialization
    void Start()
    {
        anima = GetComponent<Animator>();
        Audio = GetComponent<AudioSource>();

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
            if (currentBullets < 30)
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
        isRealoading= info.IsName("Reload");

        if (fireTimer < FireRate || currentBullets <= 0 || isRealoading ) return;

        RaycastHit hit;
        if (Physics.Raycast(shootpoint.position, shootpoint.transform.forward, out hit, weaponRange))
        {
            GameObject SpawnDecal = Instantiate(effect, hit.point, Quaternion.LookRotation(hit.normal));
            Debug.Log(hit.transform.name + "found");

            GameObject SpawnHole = Instantiate(HoleEffect, hit.point, Quaternion.FromToRotation(Vector3.forward,hit.normal));

            

            Destroy(SpawnDecal, 1f);
            Destroy(SpawnHole, 2f);
           
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

   



}
