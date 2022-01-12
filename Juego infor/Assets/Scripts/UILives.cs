using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UILives : MonoBehaviour
{

    public static int lives;

    private Text txt;

    public UIGameover gameover;

    void Start()
    {
        lives = 4;
        txt = gameObject.GetComponent<Text>();
        txt.text = "Lives: " + lives.ToString();
    }

    public void RestLives()
    {
        if (lives > 0)
        {
            lives -= 1;
            txt.text = "Lives:" + lives.ToString();
        }
        if (lives == 0)
        {
            gameover.GameOver();
            txt.text = "Lives: 0";
        }
    }



}
