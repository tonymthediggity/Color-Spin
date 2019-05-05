using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    public int colorPos;
    public Color currColor;
    public float colorChangeTimer;

    // Start is called before the first frame update
    void Awake()
    {
        






    }

    // Update is called once per frame
    void Update()
    {

        colorChangeTimer += Time.deltaTime;

        

        if(colorChangeTimer >= 2)
        {
            colorPos = Random.Range(0, 4);
            colorChangeTimer = 0;
        }

        if(colorPos == 0)
        {
            currColor = Color.yellow;
        }
        if (colorPos == 1)
        {
            currColor = Color.blue;
        }

        if (colorPos == 2)
        {
            currColor = Color.red;
        }

        if (colorPos == 3)
        {
            currColor = Color.green;
        }

        


       /* if (colorChangeTimer < 1 && colorChangeTimer > 0)
        {
            currColor = Color.red;
        }
        if (colorChangeTimer < 3 && colorChangeTimer > 2)
        {
            currColor = Color.yellow;
        }
        if (colorChangeTimer < 4 && colorChangeTimer > 3)
        {
            currColor = Color.green;
        }
        */

    }
}
