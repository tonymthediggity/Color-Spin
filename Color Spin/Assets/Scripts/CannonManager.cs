using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonManager : MonoBehaviour
{
    public float activateTimer;
    public int fpToActivate;
    public GameObject currentObj;
    public int index;
    public GameObject[] firePoints;

    // Start is called before the first frame update
    void Start()
    {


      /*  firePoints = GameObject.FindGameObjectsWithTag("FirePoint");
        for (int i = 0; i < firePoints.Length; i++)
        {
            firePoints[i].SetActive(false);

        }*/
    }

    // Update is called once per frame
    void Update()
    {
        
        firePoints = GameObject.FindGameObjectsWithTag("FirePoint");

        activateTimer += Time.deltaTime;

        if(activateTimer >= 2 && firePoints.Length != 0)
        {
            activateTimer = 0;
            index = Random.Range(0, firePoints.Length);
            currentObj = firePoints[index];
            currentObj.SetActive(true);
        }
    }
}
