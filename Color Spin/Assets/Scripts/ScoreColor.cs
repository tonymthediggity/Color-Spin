using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreColor : MonoBehaviour
{
    public Text myText;
    public Color myColor;
    public GameObject[] currentCube;

    
  



    // Start is called before the first frame update
    void Awake()
    {
        myColor = GetComponent<Text>().color;
        myText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        currentCube = GameObject.FindGameObjectsWithTag("Cube");
        myColor = currentCube[0].GetComponent<MeshRenderer>().material.color;
        myText.color = Random.ColorHSV(0, 168, 0, 168);

    }
}
