using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyManager : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] enemy;
    [SerializeField] private UI_Manager ui_Manager;
    public bool isPlayed = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startCoroutine()
    {
        StartCoroutine(enemySpawnRoutine());
    }

    public IEnumerator enemySpawnRoutine()
    {
        while(isPlayed)
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


            if (ui_Manager.score < 50)
            {
                yield return new WaitForSeconds(0.6f);
            }

            if (ui_Manager.score >= 50 && ui_Manager.score  < 100)
            {
                yield return new WaitForSeconds(0.4f);
            }
            if (ui_Manager.score >= 100 && ui_Manager.score < 300)
            {
                yield return new WaitForSeconds(0.2f);
            }
            if (ui_Manager.score >= 300 && ui_Manager.score < 500)
            {
                yield return new WaitForSeconds(0.15f);
            }
            if (ui_Manager.score >= 500)
            {
                yield return new WaitForSeconds(0.1f);
            }
        }
    }
}
