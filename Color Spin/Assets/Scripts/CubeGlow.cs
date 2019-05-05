using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGlow : MonoBehaviour
{
    public MeshRenderer myRend;
    public Color myColor;
    public Light myLight;
    public Color lightColor;

    public Vector3 myTransform;


 
    // Start is called before the first frame update
    void Awake()
    {
        myRend = GetComponent<MeshRenderer>();
        myLight = GetComponentInChildren<Light>();
        myTransform = transform.position;
        myLight.transform.position = new Vector3(myTransform.x, myTransform.y, -0.562f);

        
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        myColor = myRend.material.color;
 
        myLight.color = myColor;

        myTransform = transform.position;
        
        
    }

    private void LateUpdate()
    {
        myLight.transform.position = new Vector3(myTransform.x, myTransform.y, -0.562f);
    }
}
