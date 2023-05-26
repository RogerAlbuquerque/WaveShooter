using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] enemy;
    void Start()
    {
        StartCoroutine(enemySpawnRoutine()); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public IEnumerator enemySpawnRoutine()
    {
        while(true)
        {
            byte randomEnemySpawn = (byte)Random.Range(0, 4);
            Instantiate(enemy[randomEnemySpawn], new Vector3(0, 4, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
