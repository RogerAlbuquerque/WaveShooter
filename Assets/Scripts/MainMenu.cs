using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private SpawnEnemyManager startSpawnEnemy;
    private UI_Manager ui_Manager;
    //private FollowCamera followCamera;
    public bool isGameStarted = false;
    void Start()
    {
        ui_Manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isGameStarted)
        {
            this.gameObject.SetActive(false);
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            startGame();
        }
    }

    public void startGame()
    {
        Instantiate(playerPrefab, new Vector2(0, 5), Quaternion.identity);
        //followCamera.player = playerPrefab.transform;
        startSpawnEnemy.isPlayed = true;
        startSpawnEnemy.startCoroutine();
        isGameStarted = true;
    }

    public void gameOver()
    {
        this.gameObject.SetActive(true);
        startSpawnEnemy.isPlayed = false;
        isGameStarted = false;
        ui_Manager.UpdateHighscore();
    }
}
