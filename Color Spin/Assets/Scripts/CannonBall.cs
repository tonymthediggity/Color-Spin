using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{

    public int maxAmount;
    public int currAmount;
    public GameObject[] cannonBalls;
    public bool dontSpawn = false;

    public GameObject[] firePoints;
    public Transform firePointPos;
    public int index;
    public GameObject currentFP;
    public GameObject cannonBallPrefab;
    public float cannonBallVel;

    public float timeToActivate;
    // Start is called before the first frame update
    void Start()
    {
        timeToActivate = 0;
        firePoints = GameObject.FindGameObjectsWithTag("FirePoint");

        //firePointPos = GetComponent<Transform>().transform.Find("FirePoint");

    }

    // Update is called once per frame
    void Update()
    {
        timeToActivate += Time.deltaTime;
        cannonBalls = GameObject.FindGameObjectsWithTag("CannonBall");
        currAmount = cannonBalls.Length;
        

       if( currAmount >= maxAmount)
        {
            dontSpawn = true;
        }

       

        if (dontSpawn)
        {
            for (int i = 0; i < cannonBalls.Length; i++)
            {
                GameObject balls = cannonBalls[i];
                balls.GetComponent<Rigidbody>().isKinematic = true;
            }
        }


 
           
            



        if (timeToActivate >=   Random.Range(.75f, 1.32f) && currAmount <= maxAmount && dontSpawn == false )
        {
            index = Random.Range(0, firePoints.Length);
            currentFP = firePoints[index];
            firePointPos = currentFP.transform;

            Instantiate(cannonBallPrefab, firePointPos.transform.position, firePointPos.transform.rotation);
            timeToActivate = 0;
        } 
        
    }
}
