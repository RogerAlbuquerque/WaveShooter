using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private Transform player;

    void Update()
    {

        try
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            if (player != null)
            {
                transform.position = new Vector3(
                    Mathf.Clamp(player.position.x,-5.83f, 6.08f), 
                    Mathf.Clamp(player.position.y,0.26f, 13.72f),
                    -1
                    );
            }
        }
        catch
        {
           
        }
        


    }
}
