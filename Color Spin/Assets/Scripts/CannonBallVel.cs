using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallVel : MonoBehaviour
{

    //FIX ME FIRST
    public Rigidbody myBody;
    public MeshRenderer myRend;
    public GameObject colorManager;
    public int myVel;
    public SphereCollider myCol;
    public GameObject[] firePoints;
    public int index;
    public GameObject currFP;
    public Transform firePointPos;
    public Vector3 firePointForward;

    // Start is called before the first frame update
    void Awake()
    {
        colorManager = GameObject.Find("ColorManager");
        myRend = GetComponent<MeshRenderer>();
        myVel = Random.Range(200, 325);
        
        firePoints = GameObject.FindGameObjectsWithTag("FirePoint");

        if (firePoints.Length >= 2)
        {
            index = Random.Range(0, firePoints.Length);
            currFP = firePoints[index];
            firePointPos = currFP.GetComponent<Transform>();
            firePointForward = firePointPos.transform.forward;

        }

        if (firePoints.Length == 1)
        {
            
            firePointPos = firePoints[0].transform;
            firePointForward = firePoints[0].transform.forward;
            myBody = GetComponent<Rigidbody>();
            myRend.material.color = colorManager.GetComponent<ColorManager>().currColor;
            myBody.velocity = firePointForward * myVel;
            myCol = GetComponent<SphereCollider>();

            myCol.material.bounciness = Random.Range(0.35f, 0.6f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        myRend.material.color = colorManager.GetComponent<ColorManager>().currColor;
    }
}
