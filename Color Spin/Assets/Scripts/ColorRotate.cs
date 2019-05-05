using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorRotate : MonoBehaviour
{

    public MeshRenderer rend;

    public int []positions;
    public int currPos;

    public GameObject colorWheel;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<MeshRenderer>();
        currPos = 0;

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        colorWheel = GameObject.FindGameObjectWithTag("Wheel");
    }

    // Update is called once per frame
    void Update()
    {

        if (currPos < 0)
        {
            currPos = 3;
        }

        if (currPos > 3)
        {
            currPos = 0;
        }
        if (currPos == 0)
        {
            rend.material.color = Color.red;
            colorWheel.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if (currPos == 1)
        {
            rend.material.color = Color.blue;
            colorWheel.transform.rotation = Quaternion.Euler(0, 0, -90);

        }
        if (currPos == 2)
        {
            rend.material.color = Color.yellow;
            colorWheel.transform.rotation = Quaternion.Euler(0, 0, -180);
        }
        if (currPos == 3)
        {
            rend.material.color = Color.green;
            colorWheel.transform.rotation = Quaternion.Euler(0, 0, -270);
        }

        if (Input.GetMouseButtonDown(0))
        {
            currPos--;
            
        }

        if (Input.GetMouseButtonDown(1))
        {
            currPos++;
            
        }

        

    }
}
