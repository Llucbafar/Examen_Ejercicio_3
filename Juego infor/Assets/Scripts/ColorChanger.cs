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

    public string colortag;

    private SpriteRenderer spre;

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
                colortag = "Blue";
                break;
            case 1:
                currentcolor = Yellow;
                spre.color = Yellow;
                colortag = "Yellow";
                break;
            case 2:
                currentcolor = Green;
                spre.color = Green;
                colortag = "Green";
                break;
            case 3:
                currentcolor = Red;
                spre.color = Red;
                colortag = "Red";
                break;
        }
        StartCoroutine(WaitToChange());
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.layer == default)
        {
            ChangePlayerColor();
        }
    }
    public void ChangePlayerColor()
    {
            playercontroler.sr.color = currentcolor;
            playercontroler.tag = colortag;
            Destroy(gameObject);
    }

    IEnumerator WaitToChange()
    {
        yield return new WaitForSeconds(3);
        changecolor();
    }

}