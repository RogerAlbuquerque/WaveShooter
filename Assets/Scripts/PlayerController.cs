using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject Bullet;
    [SerializeField] private MainMenu mainMenu;
    private AudioSource audioSource;
    private Vector3 Mouse;
    private Vector2 Movement;
    private UI_Manager ui_Manager;

    public Rigidbody2D RgPlayer;
    public Animator PlayerAnimation;    
    public float Speed;
    public Vector2 direction;
    public sbyte PlayerLifes;
    public bool playerVulnerability = false;

    private SpawnEnemyManager SpawnManager;
    

    // Start is called before the first frame update
    void Start()
    {
        ui_Manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        SpawnManager = GameObject.Find("SpawnEnemyes").GetComponent<SpawnEnemyManager>();
        mainMenu = GameObject.Find("MainMenu").GetComponent<MainMenu>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        MapLimiter();

        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");
        Mouse = Input.mousePosition;
        Mouse = Camera.main.ScreenToWorldPoint(Mouse);

        direction = new Vector2(Mouse.x - transform.position.x, Mouse.y - transform.position.y);
        transform.up = -direction;

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, this.gameObject.transform);
            audioSource.Play();

        }

        


         RgPlayer.velocity = new Vector2(Movement.x, Movement.y) * Speed;


        // TESTES


    }


    void MapLimiter()
    {
        if (transform.position.y >= 17.8f)
        {
            // print(.position.y);
            transform.position = new Vector2(transform.position.x, 17.8f);
        }
        if (transform.position.y <= -5.08)
        {
            // print(.position.y);
            transform.position = new Vector2(transform.position.x, -5.08f);
        }
        if (transform.position.x >= 15.6f)
        {
            // print(.position.y);
            transform.position = new Vector2(15.6f, transform.position.y);

        }
        if (transform.position.x <= -15.52f)
        {
            // print(.position.y);
            transform.position = new Vector2(-15.52f, transform.position.y);

        }
    }

  
    public void takeDamage()
    {
        if (PlayerLifes > 0 && playerVulnerability == false)
        {
            --PlayerLifes;
            ui_Manager.UpdateCountLife();
            playerVulnerability = true;
            
            StartCoroutine(PlayerDamageAnimationRoutine());
        }
        if (PlayerLifes <= 0)
        {
            Destroy(this.gameObject);
            SpawnManager.isPlayed = false;
            GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
            for (byte i = 0; i < enemys.Length; i++) { Destroy(enemys[i]); }
            mainMenu.gameOver();

        }
    }

    public IEnumerator PlayerDamageAnimationRoutine()
    {
        GetComponent<Animator>().SetBool("Hited", true);
        RgPlayer.AddForce(-direction * 0.08f, ForceMode2D.Force);

        yield return new WaitForSeconds(0.2f);
        GetComponent<Animator>().SetBool("Hited", false);

        yield return new WaitForSeconds(0.8f);
        playerVulnerability = false;
    }
}
