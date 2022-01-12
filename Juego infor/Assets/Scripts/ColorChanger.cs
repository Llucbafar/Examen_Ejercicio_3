using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{

    public PlayerControler playercontroler;

    public Color Blue;
    public Color Yellow ;
    public Color Green;
    public Color Red;

    private int index;

    public Color currentcolor;

    private SpriteRenderer spre;

    public string colortag;

    void Start()
    {
        spre = gameObject.GetComponent<SpriteRenderer>();
        changecolor();
    }

    void changecolor()
    {
        index = Random.Range(0, 4);
        switch(index)
        {
            case 0:
                currentcolor = Blue;
                spre.color = Blue;
                break;
            case 1:
                currentcolor = Yellow;
                spre.color = Yellow;
                break;
            case 2:
                currentcolor = Green;
                spre.color = Green;
                break;
            case 3:
                currentcolor = Red;
                spre.color = Red;
                break;
        }
        StartCoroutine(WaitToChange());
    }

    public void ChangePlayerColor()
    {
        playercontroler.sr.color = currentcolor;
        playercontroler.tag = colortag;
        Destroy(gameObject);
    }

public void ChangePlayerColor(Collider2D col)
    {
        if (col.gameObject.layer == default)
        {
            ChangePlayerColor();
        }
    }
    IEnumerator WaitToChange()
    {
        yield return new WaitForSeconds(3);
        changecolor();
    }

}