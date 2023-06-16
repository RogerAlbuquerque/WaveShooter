using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rifleScript : MonoBehaviour
{

    [SerializeField]
    private PlayerController player;

    private ParticleSystem gunEffects;
    private ParticleSystem.EmissionModule particles;
    
    private AudioSource audioSource;     

    
    [Header("Weapon Stats")]
    [SerializeField] 
    private GameObject Bullet;
    [SerializeField] 
    private GameObject weakBullet;
    [SerializeField] 
    private GameObject strongBullet;
   
    [Range (1,5)]
    private float powerOfShoot = 1;

    [Header("Audios")]
    [SerializeField] 
    private AudioClip weakShootSound;
    [SerializeField] 
    private AudioClip strongShootSound;
    [SerializeField] 
    private AudioClip weakChargerSound;
    [SerializeField] 
    private AudioClip mediunChargerSound;
    [SerializeField] 
    private AudioClip strongChargerSound;
    
    


    // Start is called before the first frame update
    void Start()
    {
        gunEffects = GetComponent<ParticleSystem>();
        particles = gunEffects.emission;
        gunEffects.Stop();
        audioSource = GetComponent<AudioSource>();    
        gunEffects.Play();
        particles.rateOverTime = 0;
    }
    public void chargeShoot()
    {         
            powerOfShoot += 1 * Time.deltaTime;

        /////////////////////////////////////////////////////////////////
         
         if( powerOfShoot >= 1.5f )
        {
            
            particles.rateOverTime = 20;
                
            audioSource.loop = true;               
            if(!audioSource.isPlaying)
            {
                audioSource.Play(); 
            }

                
        }
         if(powerOfShoot >= 3 && powerOfShoot < 5)
        {
           audioSource.clip = mediunChargerSound;
             if(!audioSource.isPlaying)
            {
                audioSource.Play(); 
            }
          particles.rateOverTime = 150;

        }

         if(powerOfShoot > 5)
         {
             audioSource.clip = strongChargerSound;
               if(!audioSource.isPlaying)
            {
                audioSource.Play(); 
            }
             particles.rateOverTime = 400;
         }
        //////////////////////////////////////////////////////////////////
        // if( Input.GetKey(KeyCode.J) )
        // {
        //     audioSource.clip = weakChargerSound;
        //     audioSource.loop = true;
        //     if(!audioSource.isPlaying)
        //     {
        //         audioSource.Play(); 
        //     }
                
        // }
        //  if(Input.GetKey(KeyCode.K))
        // {
        //     audioSource.clip = mediunChargerSound;
        //     audioSource.Play();   
        // }

        //  if(Input.GetKey(KeyCode.L))
        //  {
        //     audioSource.clip = strongChargerSound;
        //     audioSource.Play();   
        //  }
    }

    public void shoot()
    {       
        powerOfShoot = (int)powerOfShoot;        
        
        if(powerOfShoot < 3)
        {
            Instantiate(Bullet, this.gameObject.transform);
            audioSource.PlayOneShot(weakShootSound);                                 
        }
        if(powerOfShoot < 5 && powerOfShoot >= 3)
        {
            Instantiate(weakBullet, this.gameObject.transform);
            audioSource.PlayOneShot(weakShootSound);
                                
        }
        if(powerOfShoot >= 5)
        {
            Instantiate(strongBullet, this.gameObject.transform);
            audioSource.PlayOneShot(strongShootSound);
                        
        }
            powerOfShoot = 1;
            particles.rateOverTime = 0;     
            audioSource.loop = false;   
            audioSource.clip = weakChargerSound;  
        
    }
}
