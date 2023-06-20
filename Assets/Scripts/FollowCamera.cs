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
                    Mathf.Clamp(player.position.x,-6.42f, 6.45f), 
                    Mathf.Clamp(player.position.y,-0.36f, 14.24f),
                    -1
                    );
            }
        }
        catch
        {
           
        }
        


    }
}
