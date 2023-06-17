using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    
    private int numberOfEnemyHited;

    private bool isGamePaused;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.isGamePaused == false)
        {
              if (transform.position.y <= -6 || transform.position.y >= 20 || transform.position.x <= -16 || transform.position.x >= 16)
        {
            Destroy(this.gameObject);
        }

        transform.Translate(Vector3.right);
        }

      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            numberOfEnemyHited++;

           if(gameObject.name == "projectile(Clone)")
           {
                Destroy(this.gameObject);
           }
           if(gameObject.name == "weak_shoot(Clone)" && numberOfEnemyHited == 2 )
           {
              Destroy(this.gameObject);
           }
        //    if(gameObject.name == "strong_shoot(Clone)")
        //    {
        //       Destroy(this.gameObject);
        //    }
           
            ///Destroy(this.gameObject);
        }

    }
}
