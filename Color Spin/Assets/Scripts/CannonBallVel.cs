using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBallVel : MonoBehaviour
{


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

 

    public CannonBall cannonBallScript;
    public GameObject myFirePoint;
    public int bounceCounter;
    public int score;

    // Start is called before the first frame update
    void Awake()
    {
        bounceCounter = 1;
        score = 5;
        cannonBallScript = GameObject.FindObjectOfType<CannonBall>();
        myFirePoint = cannonBallScript.currentFP;
        colorManager = GameObject.Find("ColorManager");
        myRend = GetComponent<MeshRenderer>();
        myVel = Random.Range(100, 223);
        myBody = GetComponent<Rigidbody>();
        myCol = GetComponent<SphereCollider>();

      //  myCol.material.bounciness = Random.Range(2, 5);

        myBody.velocity = myFirePoint.transform.forward * myVel;

      /* if (firePoints.Length == 1)
        {
            Debug.Log("FirePoints.Length= " + firePoints.Length);
            firePointPos = firePoints[0].transform;
            firePointForward = firePoints[0].transform.forward;

            myRend.material.color = colorManager.GetComponent<ColorManager>().currColor;
            myBody.velocity = firePointForward * myVel;

        }

        if (firePoints.Length == 2)
        {
            Debug.Log("FirePoints.Length= " + firePoints.Length);
            index = Random.Range(0, firePoints.Length);
            currFP = firePoints[index];
            firePointPos = currFP.GetComponent<Transform>();
            firePointForward = firePointPos.transform.forward;

        } */

       
    }

    // Update is called once per frame
    void Update()
    {
        score += bounceCounter;
        myRend.material.color = colorManager.GetComponent<ColorManager>().currColor;
    }

    private void OnCollisionEnter(Collision collision)
    {
        bounceCounter++;
    }
}
