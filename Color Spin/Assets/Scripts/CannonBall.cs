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
    // Start is called before the first frame update
    void Start()
    {
        firePoints = GameObject.FindGameObjectsWithTag("FirePoint");

        //firePointPos = GetComponent<Transform>().transform.Find("FirePoint");

    }

    // Update is called once per frame
    void Update()
    {
        

            if(firePoints.Length != 1)
            {
                index = Random.Range(0, firePoints.Length);
                currentFP = firePoints[index];
                firePointPos = currentFP.GetComponent<Transform>();

            }
            
            if(firePoints.Length == 1)
            {
                firePointPos = GameObject.FindGameObjectWithTag("FirePoint").transform;
            }
            



        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(cannonBallPrefab, firePointPos.transform.position, firePointPos.transform.rotation);
        } 
        
    }
}
