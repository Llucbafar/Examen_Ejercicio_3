using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScore : MonoBehaviour
{
    public static int points;

    private Text txt;

    void Start()
    {
        txt = gameObject.GetComponent<Text>();
        txt.text = "";
        points = 0;
    }


    public void calculateScore()
    {
        txt.text = "Balls collected: " + points + "\n";
        txt.text += "Time remaining: " + Mathf.RoundToInt(UITimer.timeRemaining).ToString() + "\n";
        txt.text += "Total score: " + (points * 1000 + Mathf.RoundToInt(UITimer.timeRemaining)*100);
    }
}
