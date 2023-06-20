using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using LootLocker.Requests;

public class UI_Manager : MonoBehaviour   
{

    [SerializeField] private Image PlayerLife;
    [SerializeField] private GameObject pauseMenu;
    [SerializeField] private AudioClip pauseGameSound;
    [SerializeField] private AudioSource audioSource; 
    
    private GameObject Life1,Life2, Life3;
   
    public int score, Highscore;
    public TextMeshProUGUI TextScore;
    string leaderBoardID = "15298";

    void Start()
    {
        Life1 = GameObject.Find("Life1");
        Life2 = GameObject.Find("Life2");
        Life3 = GameObject.Find("Life3");

       
    }

    public void UpdateScore()
    {
        ++score;
        TextScore.text = "Score: " + score;        
    }
    public void UpdateCountLife()
    {
        if(Life1.activeSelf)
        {
            Life1.SetActive(false);
        }else if(Life2.activeSelf)
        {
            Life2.SetActive(false);
        }
        else if (Life3.activeSelf)
        {
            Life3.SetActive(false);
        }
    }

    public void resetLifeCount()
    {
        Life1.SetActive(true);
        Life2.SetActive(true);
        Life3.SetActive(true);
    }

    public void UpdateHighscore()
    {
        
           if(score > Highscore) {
                Highscore = score;
                StartCoroutine(sendScoreToDatabase(Highscore));
            }
            TextScore.text = "Score: 0 " + "Highscore: " + Highscore;
           
            score = 0;
        
    }

    public void pauseGame(bool isPaused)
    {
        pauseMenu.SetActive(isPaused);
        audioSource.PlayOneShot(pauseGameSound);     
    }




    public IEnumerator sendScoreToDatabase(int scoreToUpload)
    {
        bool done = false;
        string playerID = PlayerPrefs.GetString("PlayerID");	// A variável criada antes que tem o id do player.
        LootLockerSDKManager.SubmitScore(playerID,scoreToUpload, leaderBoardID, (response) =>{
        
        if(response.success)
            {
                Debug.Log("Successfully uploaded score");
                done = true;
            }
        else
            {
                Debug.Log("Failed: " + response.Error);
                done = true;
            }
        });

        yield return new WaitWhile(() => done == false);	

    }

   
}
