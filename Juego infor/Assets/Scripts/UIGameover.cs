using System.Collections;
using System.Collections.Generic;
using UnityEngine;  
using UnityEngine.UI;

public class UIGameover : MonoBehaviour
{

    private Text txt;

    public UIScore Uiscore;

    public bool finished;

    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        finished = false;
    }

    public void GameOver()
    {
        txt.text = "GameOver"+"\n";
        txt.text += "Press F to play again";
        Uiscore.calculateScore();
        Time.timeScale = 0;
        finished = true;
    }

    public void win()
    {
        txt.text = "WINNER"+"\n";
        txt.text += "Press F to play again";
        Uiscore.calculateScore();
        Time.timeScale = 0;
        finished = true;
    }

}
