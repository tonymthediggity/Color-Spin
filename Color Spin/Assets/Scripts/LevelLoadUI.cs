using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelLoadUI : MonoBehaviour
{
    public Scene thisScene;
    public Text levelNameText;
    public Text parText;
    public Text readyText;
    public GameObject gameManager;
    public bool isEnabled;
    public CannonBall cannonManager;

    // Start is called before the first frame update
    void Awake()
    {
        thisScene = SceneManager.GetActiveScene();
        levelNameText.text = thisScene.name;
        gameManager = GameObject.Find("GameManager");
        cannonManager = GameObject.Find("CannonWScript").GetComponent<CannonBall>();
        isEnabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnabled)
        {
            parText.text = "Par " + gameManager.GetComponent<ScoreAndTimer>().par;
        }

        if (cannonManager.currAmount < cannonManager.maxAmount && cannonManager.dontSpawn == false)
        {
            isEnabled = true;
        }

        if (cannonManager.currAmount >= cannonManager.maxAmount && cannonManager.dontSpawn == true)
        {
            isEnabled = false;
        }

        if(isEnabled == false)
        {
            gameObject.SetActive(false);
        }
    }
}
