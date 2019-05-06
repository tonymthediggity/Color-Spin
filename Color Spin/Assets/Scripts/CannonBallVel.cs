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

    public ParticleSystem myParticle;


    public GameObject ScoreManager;
    public CannonBall cannonBallScript;
    public GameObject myFirePoint;
    public int bounceCounter;
    public int score;
    public int scoreToAdd;

    // Start is called before the first frame update
    void Awake()
    {

        ScoreManager = GameObject.Find("GameManager");
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
        scoreToAdd = GameObject.Find("GameManager").GetComponent<ScoreAndTimer>().scoreToGive;
        myRend.material.color = colorManager.GetComponent<ColorManager>().currColor;

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("PlayerCannonBall"))
        {
            score += scoreToAdd;
            ScoreManager.GetComponent<ScoreAndTimer>().currScore += (scoreToAdd / 10);
            Instantiate(myParticle, other.transform.position, other.transform.rotation);

           
           
        }
        if (!other.collider.CompareTag("PlayerCannonBall"))
        {

        }
    }
}
