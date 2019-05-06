using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VisualizerColor : MonoBehaviour
{
    public Image[] myVisualizers;

    public ColorManager colorChanger;

   






    // Start is called before the first frame update
    void Awake()
    {
        // myVisualizers = GetComponentsInChildren<Image>();
        colorChanger = GameObject.Find("ColorManager").GetComponent<ColorManager>();

        //myColor = .color;
        //myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
      


        


            

        foreach (Image visImages in GetComponentsInChildren<Image>())
        {
            
            visImages.color = Color.Lerp(colorChanger.currColor, visImages.color, Mathf.PingPong(Time.time, 1.15f));
            var tempColor = visImages.color;
            tempColor.a = .50f;
            visImages.color = tempColor;

            
            
            
        }
        
      

    }
}
