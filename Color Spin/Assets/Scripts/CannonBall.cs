using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{

    //FIX ME FIRST

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

 
           
            



        if (timeToActivate >=   Random.Range(.75f, 1.32f))
        {
            index = Random.Range(0, firePoints.Length);
            currentFP = firePoints[index];
            firePointPos = currentFP.transform;

            Instantiate(cannonBallPrefab, firePointPos.transform.position, firePointPos.transform.rotation);
            timeToActivate = 0;
        } 
        
    }
}
