using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGame : MonoBehaviour
{

    public GameObject player;
    public GameObject gameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        gameOverPanel.SetActive(false);
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<ColorCheck>().playerHealth <= 0)
        {
          
                Time.timeScale = 0;
                gameOverPanel.SetActive(true);

           
        }
    }
}
