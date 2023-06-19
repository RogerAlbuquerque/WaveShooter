using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab,Leaderboard,Logo;
    [SerializeField] private SpawnEnemyManager startSpawnEnemy; 
    private UI_Manager ui_Manager;

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
        if(Input.GetKeyDown(KeyCode.Return) && Logo.activeSelf == true)
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

     public void handleLeaderboardMenu()
    {
        Leaderboard.SetActive(!Leaderboard.activeSelf);
        Logo.SetActive(!Logo.activeSelf);
    }

}
