using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextColor : MonoBehaviour
{

    public Text myText;
    public float timeTilChange = 1.5f;
    public bool changeColor;
    public int colorPos;
    public Color targetColor;
    public Color currColor;

    // Start is called before the first frame update
    void Start()
    {
        myText = GetComponent<Text>();
        colorPos = 0;
        currColor = Color.white;
    }

    // Update is called once per frame
    void Update()
    {

        timeTilChange -= Time.deltaTime;
        currColor = myText.color;

        if (timeTilChange <= 0)
        {
            colorPos++;
            ChangeColor();

        }

        if (colorPos > 4)
        {
            colorPos = 0;
        }

    }

    public void ChangeColor()
    {

        if (colorPos == 0)
        {
            targetColor = Color.white;
            myText.color = Color.white;
            timeTilChange = 1.5f;
        }

        if (colorPos == 1)
        {
            targetColor = Color.blue;
            myText.color = Color.blue; ;
            timeTilChange = 1.5f;
        }

        if (colorPos == 2)
        {
            targetColor = Color.red;
            myText.color = Color.red;
            timeTilChange = 1.5f;
        }

        if (colorPos == 3)
        {
            targetColor = Color.green;
            myText.color = Color.green;
            timeTilChange = 1.5f;
        }

        if (colorPos == 4)
        {
            targetColor = Color.yellow;
            myText.color = Color.yellow;
            timeTilChange = 1.5f;
        }

    }
}
