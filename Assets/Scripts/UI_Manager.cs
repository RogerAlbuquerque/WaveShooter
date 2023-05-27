using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour   
{
    [SerializeField] TextMeshProUGUI TextScore;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void UpdateScore()
    {
        ++score;
        TextScore.text = "Score: " + score;
    }
}
