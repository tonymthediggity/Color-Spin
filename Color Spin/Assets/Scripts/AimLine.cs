using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLine : MonoBehaviour
{

    public LineRenderer myLine;
    public GameObject myFP;
    public GameObject myEP;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        myLine = GetComponent<LineRenderer>();
        myLine.startWidth = 3;
        
        
    }

    // Update is called once per frame
    void Update()
    {

        Vector3[] positions = new Vector3[2];
        positions[0] = myFP.transform.position;
        positions[1] = myEP.transform.position;
        myLine.SetPositions(positions);
        myLine.alignment = LineAlignment.TransformZ;
        

    }


}
