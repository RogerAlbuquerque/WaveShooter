using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    // Start is called before the first frame update
    private Transform player;
    public NavMeshAgent agent;
    public float speed;
    void Start()
    {
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.Find("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        // transform.position = Vector3.Lerp(transform.position, player.position, speed * Time.deltaTime);
        agent.SetDestination(player.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Bullet")
        {
            Destroy(this.gameObject);
        }
       
    }

}
