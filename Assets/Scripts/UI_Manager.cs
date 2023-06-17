using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UI_Manager : MonoBehaviour   
{

    [SerializeField] private Image PlayerLife;
    [SerializeField] private GameObject pauseMenu;
    
    private GameObject Life1,Life2, Life3;
   
    public int score, Highscore;
    public TextMeshProUGUI TextScore;

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

    public void UpdateHighscore()
    {
        
           if(score > Highscore) {Highscore = score;}
            TextScore.text = "Score: 0 " + "Highscore: " + Highscore;
            score = 0;
        
    }

    public void pauseGame(bool isPaused)
    {
        pauseMenu.SetActive(isPaused);
    }
}
