using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{

    public int rotateAxis;


    // Start is called before the first frame update
    void Awake()
    {
        rotateAxis = Random.Range(0, 2);
    }

    // Update is called once per frame
    void Update()
    {
        if (rotateAxis == 0)
        {
            transform.Rotate(30 * Time.deltaTime, 0, 0);
        }

        if (rotateAxis == 1)
        {
            transform.Rotate(0,  30* Time.deltaTime, 0);
        }

        

        if (rotateAxis == 2)
        {
            transform.Rotate(0,0, 30 * Time.deltaTime);
        }



    }
}
