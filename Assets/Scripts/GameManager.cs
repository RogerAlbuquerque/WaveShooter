using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool isGamePaused;
    private UI_Manager ui_Manager;
    // Start is called before the first frame update
    void Start()
    {
        ui_Manager = GameObject.Find("Canvas").GetComponent<UI_Manager>();
    }

    // Update is called once per frame
    void Update()
    {
        
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
}
