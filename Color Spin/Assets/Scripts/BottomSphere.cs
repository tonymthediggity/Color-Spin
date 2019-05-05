using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomSphere : MonoBehaviour
{
    public MeshRenderer rend;
    public int playerPos;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();

    }

    // Update is called once per frame
    void Update()
    {
       

        playerPos = GameObject.FindGameObjectWithTag("Player").GetComponent<ColorRotate>().currPos;

        

        if (playerPos == 0)
        {
            rend.material.color = Color.green; // works with no transparency.
            

            
            

        }
        if (playerPos == 1)
        {
            rend.material.color = Color.yellow;
        }
        if (playerPos == 2)
        {
            rend.material.color = Color.red;
        }
        if (playerPos == 3)
        {
            rend.material.color = Color.blue;
        }
    }
}
