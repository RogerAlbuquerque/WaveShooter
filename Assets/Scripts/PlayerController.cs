using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D RgPlayer;
    public Animator PlayerAnimation;
    private float ControllerX,ControllerY;
    public float Speed;
    private Vector2 Movement;
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

        RgPlayer.velocity = new Vector2(Movement.x, Movement.y) * Speed;


        // TESTES
        if (Input.GetKey(KeyCode.L))
        {
        
        }

        PlayerAnimation.SetFloat("Move X", Movement.x);
        PlayerAnimation.SetFloat("Move Y", Movement.y);
        PlayerAnimation.SetFloat("Velocity", Movement.sqrMagnitude);

       
        if (Movement != Vector2.zero)
        {
            PlayerAnimation.SetFloat("LookDirectionX", Movement.x);
            PlayerAnimation.SetFloat("LookDirectionY", Movement.y);
        }
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
