using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LootLocker.Requests;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab,Leaderboard,mainMenu;
    [SerializeField] private SpawnEnemyManager startSpawnEnemy; 

    public bool isGameStarted = false;


    public bool isGamePaused = false;
    private UI_Manager ui_Manager;
    public TextMeshProUGUI username, ListRankingScore,listRankingPlayers;
    // Start is called before the first frame update
    void Start()
    {
        ui_Manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
        username = GameObject.Find("username").GetComponent<TextMeshProUGUI>();

       StartCoroutine(LoginRoutine());
    }

    // Update is called once per frame
    void Update()
    {
         
        if(Input.GetKeyDown(KeyCode.Return) && mainMenu.activeSelf == true)
        {
            startGame();
        }
        
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale != 0f)
            {
                 Time.timeScale = 0f;
                 isGamePaused = true;
                 
            }
            else
            {
                Time.timeScale = 1f;
                isGamePaused = false;
            }
            ui_Manager.pauseGame(isGamePaused);
          
        }
    }

    

    public void startGame()
    {
        Instantiate(playerPrefab, new Vector2(0, 5), Quaternion.identity);
        //followCamera.player = playerPrefab.transform;
        startSpawnEnemy.isPlayed = true;
        startSpawnEnemy.startCoroutine();
        isGameStarted = true;
        mainMenu.SetActive(false);
    }

    public void gameOver()
    {
        this.gameObject.SetActive(true);
        startSpawnEnemy.isPlayed = false;
        isGameStarted = false;
        ui_Manager.UpdateHighscore();
        ui_Manager.resetLifeCount();
        mainMenu.SetActive(true);
    }
    
    public void handleLeaderboardMenu()
    {
        Leaderboard.SetActive(!Leaderboard.activeSelf);
        mainMenu.SetActive(!mainMenu.activeSelf);

       
            StartCoroutine(getLeaderboard());
        
    }

    IEnumerator LoginRoutine()
    {
        bool done = false;
        LootLockerSDKManager.StartGuestSession((response)=>
        {
            if(response.success)
            {
                Debug.Log("Player was logged in");
                PlayerPrefs.SetString("PlayerID", response.player_id.ToString());
                done = true;
            }

            else
            {
                Debug.Log("Could not start session");
                done = true;
            }
        });

        yield return new WaitWhile(() => done == false);	// Com isso a rotina espera ate dar sucesso ou erro para parar
    }
    
     public IEnumerator getLeaderboard()
    {
        bool done = false;
        LootLockerSDKManager.GetScoreList("15298", 10, 0, (response) =>	// o 10 e o 0, é o primeiro colocado e o mais de baixo
        {
            if(response.success)
            {
                string playerNames = "Names\n";
                string playerScores = "Scores\n";

                LootLockerLeaderboardMember[] members = response.items;		// Variável para armazenar tudo que vem da resposta, todos os scores

                for(int i = 0; i < members.Length; i++ )
                {
                    playerNames += members[i].rank + ". ";			// Isso aqui vai fazer ficar com o nome no topo e o nome dos player abaixo
                    
                    if(members[i].player.name != "")
                    {
                        playerNames += members[i].player.name;		// Aqui vai ficar o nome do lado do rank do player
                    }

                    else
                    {
                        playerNames += members[i].player.id;
                    }
        
                    playerScores += members[i].score + "\n";
                    playerNames += "\n";
                }
                done = true;
                
                ListRankingScore.text = playerScores;
                listRankingPlayers.text = playerNames;

		    }

            else
            {
                Debug.Log("Failed" + response.Error);
                done = true;
            }
        });
	yield return new WaitWhile(() => done == false);
}

    public void updateUsername()
    {
        if(username.text.Length > 1)
        {
            LootLockerSDKManager.SetPlayerName(username.text, (response)=>
            {
            if(response.success){Debug.Log("SUCESSS");}
            else{Debug.Log("WRONG");}
            });
            PlayerPrefs.SetString("PlayerID", username.text);
        };
       
    }
}
