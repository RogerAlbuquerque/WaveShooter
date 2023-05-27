using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("destroyThis", 0.6f, 0);
    }

    // Update is called once per frame
    void destroyThis()
    {
        Destroy(this.gameObject);
    }
}
