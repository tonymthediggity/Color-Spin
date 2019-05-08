using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndTimer : MonoBehaviour
{
    public int par;
    public GameObject[] cannonBalls;

    public int scoreToGive;
    public int currScore;
    public int finalScore;

    public int score;
    public Text scoreText;
    public Text parText;
    public CannonBall cannonBallScript;

    public void Awake()
    {

       
        cannonBallScript = GameObject.Find("CannonWScript").GetComponent<CannonBall>();
        par = Mathf.RoundToInt(cannonBallScript.maxAmount * 1.10f);
        
        
    }

    public void Update()
    {
        parText.text = "Par: " + par;
        scoreText.text = "Score: " + currScore;

        
    }
}
