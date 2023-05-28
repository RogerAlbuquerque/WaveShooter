using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject player;
    private UI_Manager ui_Manager;
    [SerializeField] private GameObject enemyDeathAnim;
    public NavMeshAgent agent;
    public float speed;
    public PlayerController playerScript;
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<PlayerController>();
        ui_Manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();


    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.Lerp(transform.position, player.position, speed * Time.deltaTime);
        agent.SetDestination(player.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            ui_Manager.UpdateScore();
            Instantiate(enemyDeathAnim, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        DamageOnPlayer(collision);


    }

    void DamageOnPlayer(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (playerScript.PlayerLifes > 0 && playerScript.playerVulnerability == false)
            {
                ui_Manager.UpdateCountLife();
                playerScript.playerVulnerability = true;
                playerScript.PlayerLifes--;
                StartCoroutine(PlayerDamageAnimationRoutine());
            }
            if (playerScript.PlayerLifes <= 0)
            {
                Destroy(player);
                GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");
                for(byte i = 0; i < enemys.Length; i++) { Destroy(enemys[i]); }
            }

            //Destroy(this.gameObject);
        }
    }

    public IEnumerator PlayerDamageAnimationRoutine() 
    {
        
        
        player.GetComponent<Animator>().SetBool("Hited", true);
        player.GetComponent<Rigidbody2D>().AddForce(-playerScript.direction * 0.08f, ForceMode2D.Force);

        yield return new WaitForSeconds(0.2f);
        player.GetComponent<Animator>().SetBool("Hited", false);

        yield return new WaitForSeconds(0.8f);
        playerScript.playerVulnerability = false;
    }

    
}