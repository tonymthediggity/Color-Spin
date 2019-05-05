using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuColorChange : MonoBehaviour
{
    public float timeTilChange = 1;
    public MeshRenderer myRend;
    public Color currColor;
    public Color targetColor;
    public bool changeColor;
    public int colorPos;

    // Start is called before the first frame update
    void Start()
    {

        myRend = GetComponent<MeshRenderer>();
 
        colorPos = 0;

        currColor = myRend.material.color;
        myRend.material.color = Color.white;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        timeTilChange -= Time.deltaTime;

        if(timeTilChange <= 0)
        {

           
           

            colorPos++;
            ChangeColor();
            
        }

        if(colorPos > 4)
        {
            colorPos = 0;
        }

    }

    public void ChangeColor()
    {

        if(colorPos == 0)
        {
            currColor = myRend.material.color;
            targetColor = Color.white;
            myRend.material.color = Color.white;
            timeTilChange = 1.5f;
        }

        if (colorPos == 1)
        {
            currColor = myRend.material.color;
            targetColor = Color.blue;
            myRend.material.color = Color.blue;
            timeTilChange = 1.5f;
        }

        if (colorPos == 2)
        {
            currColor = myRend.material.color;
            targetColor = Color.red;
            myRend.material.color = Color.red;
            timeTilChange = 1.5f;
        }

        if (colorPos == 3)
        {
            currColor = myRend.material.color;
            targetColor = Color.green;
            myRend.material.color = Color.green;
            timeTilChange = 1.5f;
        }

        if (colorPos == 4)
        {
            currColor = myRend.material.color;
            targetColor = Color.yellow;
            myRend.material.color = Color.yellow;
            timeTilChange = 1.5f;
        }

    }
}
