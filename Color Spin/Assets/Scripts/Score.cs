using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int score;
    public GameObject scoreHolder;



    public GameObject destroyZone;
    // Start is called before the first frame update
    void Awake()
    {
        scoreHolder = GameObject.Find("GameManager");

    }

    // Update is called once per frame
    void Update()
    {


        score += scoreHolder.GetComponent<ScoreAndTimer>().scoreToGive;



    }
}
