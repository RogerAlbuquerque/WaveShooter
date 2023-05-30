using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject enemyDeathAnim;
    [SerializeField] private AudioClip clip;
    private GameObject player;
    private PlayerController playerScript;
    private UI_Manager ui_Manager;   
    public NavMeshAgent agent;
    public float speed;

    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.FindGameObjectWithTag("Player");
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
            AudioSource.PlayClipAtPoint(clip,Camera.main.transform.position, 1f);
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
            playerScript.takeDamage();
        }
    }


} 
    
