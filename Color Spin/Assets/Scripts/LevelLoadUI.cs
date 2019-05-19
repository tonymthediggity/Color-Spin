using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoadUI : MonoBehaviour
{
    public Transform myTrans;
 
    public Scene thisScene;
    public Image levelManager;
    public GameObject player;

    public float timer;
    public float timeToStartScene;
    public bool startSceneTimer;
    public GameObject boss;
    
    public Text levelNameText;
    public Text parText;
    public Text readyText;
    public GameObject buttonPrefab;
    public GameObject retryButtonPrefab;
    public int finalScore;
    public GameObject gameManager;
    public bool levelStartEnable;
    public bool levelEndContEnable;
    public bool levelEndFailEnable;
    public CannonBall cannonManager;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("PlayerParent");
        boss = GameObject.FindGameObjectWithTag("Boss");
        levelStartEnable = true;
        levelEndFailEnable = false;
        startSceneTimer = true;
        timeToStartScene = 0;
        levelManager = GameObject.Find("LevelLoadUI").GetComponent<Image>();

        thisScene = SceneManager.GetActiveScene();
        levelNameText.text = thisScene.name;
        gameManager = GameObject.Find("GameManager");
        cannonManager = GameObject.Find("CannonWScript").GetComponent<CannonBall>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (startSceneTimer == true)
        {
            timeToStartScene += Time.deltaTime;
        }


        if (levelStartEnable == true && timeToStartScene < 3)
          {
              Time.timeScale = 1;
            startSceneTimer = true;
            var tempColor = levelManager.color;
              var tempColor1 = parText.color;
              var tempColor2 = levelNameText.color;
              var tempColor3 = readyText.color;
              if(timeToStartScene > 4)
            {
                levelStartEnable = false;
            }

              tempColor.a = 1f;
              tempColor1.a = 1f;
              tempColor2.a = 1f;
              tempColor3.a = 1f;

              levelManager.color = tempColor;
              parText.color = tempColor1;
              levelNameText.color = tempColor2;
              readyText.color = tempColor3;

            parText.text = "Par: " + gameManager.GetComponent<ScoreAndTimer>().par;

          }
          else if (timeToStartScene >= 3)
          {
              levelStartEnable = false;
              var tempColor = levelManager.color;
              var tempColor1 = parText.color;
              var tempColor2 = levelNameText.color;
              var tempColor3 = readyText.color;

              tempColor.a = 0f;
              tempColor1.a = 0f;
              tempColor2.a = 0f;
              tempColor3.a = 0f;
              startSceneTimer = false;
              timeToStartScene = 0;

              levelManager.color = tempColor;
              parText.color = tempColor1;
              levelNameText.color = tempColor2;
              readyText.color = tempColor3;
          }


          if(cannonManager.currAmount <= 0 && levelStartEnable == false && player.GetComponent<MovePlayer>().numberOfShots <= gameManager.GetComponent<ScoreAndTimer>().par && boss == null )
          {
              levelEndContEnable = true;
          }

        if (cannonManager.currAmount <= 0 && levelStartEnable == false && player.GetComponent<MovePlayer>().numberOfShots > gameManager.GetComponent<ScoreAndTimer>().par)
        {
            levelEndFailEnable = true;
        }

        if (levelEndContEnable == true)
          {
              var tempColor = levelManager.color;
              var tempColor1 = parText.color;
              var tempColor2 = levelNameText.color;
              var tempColor3 = readyText.color;

              tempColor.a = 1f;
              tempColor1.a = 1f;
              tempColor2.a = 0f;
              tempColor3.a = 1f;

              levelManager.color = tempColor;
              parText.color = tempColor1;
              levelNameText.color = tempColor2;
              readyText.color = tempColor3;
              Time.timeScale = 0;

              Cursor.visible = true;

              finalScore = gameManager.GetComponent<ScoreAndTimer>().currScore + (gameManager.GetComponent<ScoreAndTimer>().par - player.GetComponent<MovePlayer>().numberOfShots) + Mathf.RoundToInt(timer);
              readyText.text = "Final Score: " + finalScore;
              parText.text = "Par: " + gameManager.GetComponent<ScoreAndTimer>().par + " " + "Shots: " + player.GetComponent<MovePlayer>().numberOfShots;

              if (GameObject.Find("ContinueButton(Clone)") == false)
              {
                  GameObject newButton = Instantiate(buttonPrefab, transform.position, transform.rotation) as GameObject;
                  newButton.transform.SetParent(gameObject.transform);
                  newButton.transform.localPosition = new Vector3(0, -127, 0);
              }
          }

        if (levelEndFailEnable == true)
        {
            var tempColor = levelManager.color;
            var tempColor1 = parText.color;
            var tempColor2 = levelNameText.color;
            var tempColor3 = readyText.color;

            tempColor.a = 1f;
            tempColor1.a = 1f;
            tempColor2.a = 0f;
            tempColor3.a = 1f;

            levelManager.color = tempColor;
            parText.color = tempColor1;
            levelNameText.color = tempColor2;
            readyText.color = tempColor3;
            Time.timeScale = 0;

            Cursor.visible = true;

            finalScore = gameManager.GetComponent<ScoreAndTimer>().currScore + (gameManager.GetComponent<ScoreAndTimer>().par - player.GetComponent<MovePlayer>().numberOfShots) + Mathf.RoundToInt(timer);
            readyText.text = "Failure";
            parText.text = "Par: " + gameManager.GetComponent<ScoreAndTimer>().par + " " + "Shots: " + player.GetComponent<MovePlayer>().numberOfShots;

            if (GameObject.Find("RetryButton(Clone)") == false)
            {
                GameObject newButton = Instantiate(retryButtonPrefab, transform.position, transform.rotation) as GameObject;
                newButton.transform.SetParent(gameObject.transform);
                newButton.transform.localPosition = new Vector3(0, -127, 0);
            }
        }






    }
}
