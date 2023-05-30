using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        try
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            if (player != null)
            {
                transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
            }
        }
        catch
        {
            print("Não encontrou ainda");
        }
        


    }
}
