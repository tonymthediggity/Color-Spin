using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleColorChange : MonoBehaviour
{

    public GameObject colorManager;
    public MeshRenderer myRend;
    // Start is called before the first frame update
    void Awake()
    {
        colorManager = GameObject.Find("ColorManager");
        myRend = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        myRend.material.color = colorManager.GetComponent<ColorManager>().currColor;
    }
}
