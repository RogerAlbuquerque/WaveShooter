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
    [SerializeField] 
    private AudioClip strongShootSound;
    [Range (1,5)]
    private float powerOfShoot = 1;


    // Start is called before the first frame update
    void Start()
    {
        gunEffects = GetComponent<ParticleSystem>();
        particles = gunEffects.emission;
        gunEffects.Stop();
        audioSource = GetComponent<AudioSource>();    
    }

    // Update is called once per frame
    void Update()
    {

        if(powerOfShoot < 2 && powerOfShoot >= 1.5f)
        {
            gunEffects.Play();
            particles.rateOverTime = 20;
            print("TA 50 AS PARTICULAS");
        }
         if(powerOfShoot < 5 && powerOfShoot >= 3)
        {
            gunEffects.Play();
            particles.rateOverTime = 50;
            print("TA 50 AS PARTICULAS");
        }

         if(powerOfShoot > 5)
         {
            particles.rateOverTime = 400;
            print("250 PARTICULAS");
         }
    }

    public void chargeShoot()
    {
         if (Input.GetButton("Fire1"))
        {
           
            powerOfShoot += 1 * Time.deltaTime;
        }

        
        
    }
    public void shoot()
    {       
        powerOfShoot = (int)powerOfShoot;        
        
        if(powerOfShoot < 3)
        {
            Instantiate(Bullet, this.gameObject.transform);
            audioSource.Play();                                 
        }
        if(powerOfShoot < 5 && powerOfShoot >= 3)
        {
            Instantiate(weakBullet, this.gameObject.transform);
            audioSource.Play();
                                
        }
        if(powerOfShoot >= 5)
        {
            Instantiate(strongBullet, this.gameObject.transform);
            audioSource.PlayOneShot(strongShootSound);
                        
        }
            powerOfShoot = 1;
            gunEffects.Stop();          
        
    }
}
