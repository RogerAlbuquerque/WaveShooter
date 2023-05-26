using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Transform player = GameObject.Find("Player").transform;
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
    }
}
