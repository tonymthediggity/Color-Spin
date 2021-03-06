﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{

    public CannonBall cannonScript;
    // Start is called before the first frame update
    void Awake()
    {
        cannonScript = GameObject.Find("CannonWScript").GetComponent<CannonBall>();
        GameObject[] levelLoader = GameObject.FindGameObjectsWithTag("LevelLoader");

      /*  if (levelLoader.Length > 1)
        {
            Destroy(this.gameObject);
        }
        DontDestroyOnLoad(this.gameObject);

    */
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void LoadNextScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public  void ReloadRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
