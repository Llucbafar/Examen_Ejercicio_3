using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{
    public static float timeRemaining = 30;

     private Text txt;

     public UIGameover gameover;

    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        timeRemaining = 30;
    }

    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            txt.text = "Timer: " + Mathf.RoundToInt(timeRemaining).ToString();
        }
        else
        {
            gameover.GameOver();
        }
        
    }
}
