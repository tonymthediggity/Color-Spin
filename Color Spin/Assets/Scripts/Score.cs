using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int score;
    public CannonBallVel ballVelScript;



    public GameObject destroyZone;
    // Start is called before the first frame update
    void Awake()
    {
        ballVelScript = GetComponent<CannonBallVel>();
        destroyZone = GameObject.Find("DestroyZone");
    }

    // Update is called once per frame
    void Update()
    {
       

        score = Mathf.RoundToInt(ballVelScript.myVel / 10); 



    }
}
