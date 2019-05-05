using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizerColor : MonoBehaviour
{
    public Image[] myVisualizers;

    public GameObject[] currentCube;

    public Color targetColor;






    // Start is called before the first frame update
    void Awake()
    {
       // myVisualizers = GetComponentsInChildren<Image>();
       

        //myColor = .color;
        //myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentCube = GameObject.FindGameObjectsWithTag("Cube");


        if (currentCube.Length != 0)
        {


            targetColor = currentCube[0].GetComponent<MeshRenderer>().material.color;
        }

        foreach (Image visImages in GetComponentsInChildren<Image>())
        {
            
            visImages.color = Color.Lerp(targetColor, visImages.color, Mathf.PingPong(Time.time, 1.15f));
            var tempColor = visImages.color;
            tempColor.a = .50f;
            visImages.color = tempColor;

            
            
            
        }
        
      

    }
}
