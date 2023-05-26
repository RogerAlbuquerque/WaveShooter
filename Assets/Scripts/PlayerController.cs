using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D RgPlayer;
    public Animator PlayerAnimation;
    private Vector3 Mouse;
    public float Speed;
    private Vector2 Movement;
    [SerializeField] private GameObject Bullet;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        MapLimiter();

        Movement.x = Input.GetAxis("Horizontal");
        Movement.y = Input.GetAxis("Vertical");
        Mouse = Input.mousePosition;
        Mouse = Camera.main.ScreenToWorldPoint(Mouse);

        Vector2 direction = new Vector2(Mouse.x - transform.position.x, Mouse.y - transform.position.y);
        transform.up = -direction;


        // RgPlayer.velocity = new Vector2(Mouse.x - transform.position.x, Mouse.y - transform.position.y) * Speed;


        // TESTES
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(Bullet, this.gameObject.transform);
        }

        if(Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, Speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, -Speed * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Speed * Time.deltaTime,0 , 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(-Speed * Time.deltaTime, 0 , 0);
        }




        //transform.Rotate(new Vector3(transform.rotation.x, transform.rotation.y, -1));


        //PlayerAnimation.SetFloat("Move X", Movement.x);
        //PlayerAnimation.SetFloat("Move Y", Movement.y);
        //PlayerAnimation.SetFloat("Velocity", Movement.sqrMagnitude);


        // if (Movement != Vector2.zero)
        //{
        //  PlayerAnimation.SetFloat("LookDirectionX", Movement.x);
        //PlayerAnimation.SetFloat("LookDirectionY", Movement.y);
        //}
        //skinController();





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

  
}
