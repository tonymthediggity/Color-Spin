using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChange : MonoBehaviour
{

    public MeshRenderer rend;
    public int colorValue;
    // Start is called before the first frame update
    void Awake()
    {
        rend = GetComponent<MeshRenderer>();
        
        colorValue = Random.Range(0, 4);

        



    }

    // Update is called once per frame
    void Update()
    {
        if (colorValue == 1)
        {
            rend.material.color = Color.blue;
        }
        if (colorValue == 0)
        {
            rend.material.color = Color.red;
        }
        if (colorValue == 2)
        {
            rend.material.color = Color.yellow;
        }
        if (colorValue == 3)
        {
            rend.material.color = Color.green;
        }

    }
}
