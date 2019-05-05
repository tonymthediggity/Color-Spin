using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int score;

    public int healthToGive;
    public float yPos;
    public float yPosDZ;
    public float distanceFromDZ;
    public GameObject destroyZone;
    // Start is called before the first frame update
    void Awake()
    {
        
        destroyZone = GameObject.Find("DestroyZone");
    }

    // Update is called once per frame
    void Update()
    {
        yPos = transform.position.y;

       
        yPosDZ = destroyZone.transform.localPosition.y;

        distanceFromDZ = Mathf.Round( yPos - yPosDZ);

        if (distanceFromDZ < 0)
        {
            distanceFromDZ = Mathf.Round(distanceFromDZ / 2);
        }


        if(distanceFromDZ > 20)
        {
            healthToGive = 5;
        }
        else
        {
            healthToGive = 0;
        }

        score = Mathf.RoundToInt(distanceFromDZ ); 

        if(score < 1)
        {
            score = (Random.Range(1, 6));
        }


    }
}
