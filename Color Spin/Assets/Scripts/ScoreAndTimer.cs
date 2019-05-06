using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreAndTimer : MonoBehaviour
{
    public int scoreToGive;
    public AudioSource currSong;
    public float gameTimer;
    public int currScore;

    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        currSong = GameObject.Find("audio").GetComponent<AudioSource>();
        gameTimer = currSong.clip.length;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + currScore;
        if(currScore <= 0)
        {
            currScore = Random.Range(1, 15);
        }
        gameTimer -= Time.deltaTime;
        scoreToGive = Mathf.RoundToInt(gameTimer);

        

        if(gameTimer <= 0)
        {
            EndLevel();
        }
    }

    public void EndLevel()
    {

    }
}
