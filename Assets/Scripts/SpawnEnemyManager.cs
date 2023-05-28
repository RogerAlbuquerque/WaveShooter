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
            if(randomEnemySpawn == 0)
            {
                Instantiate(enemy[randomEnemySpawn], new Vector3(-15, 7, 0), Quaternion.identity);
            }
            if (randomEnemySpawn == 1)
            {
                Instantiate(enemy[randomEnemySpawn], new Vector3(15, 7, 0), Quaternion.identity);
            }
            if (randomEnemySpawn == 2)
            {
                Instantiate(enemy[randomEnemySpawn], new Vector3(-2f, 16.7f, 0), Quaternion.identity);
            }
            if (randomEnemySpawn == 3)
            {
                Instantiate(enemy[randomEnemySpawn], new Vector3(-2, -5.1f, 0), Quaternion.identity);
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}
