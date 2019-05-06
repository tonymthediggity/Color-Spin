using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{

    public int score;
    public PlayerCannonBall pcbScore;



    public GameObject destroyZone;
    // Start is called before the first frame update
    void Awake()
    {
        pcbScore = GameObject.Find("PlayerCannonBall").GetComponent<PlayerCannonBall>();
        destroyZone = GameObject.Find("DestroyZone");
    }

    // Update is called once per frame
    void Update()
    {


        score += pcbScore.score;



    }
}
