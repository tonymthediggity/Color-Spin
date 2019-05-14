using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


[System.Serializable]
public class LevelStatTrack : MonoBehaviour
{

    public int currLevel;

    public string sceneName;
    public string currScene;
    public bool level1Complete;
    public bool level2Complete;
    public bool level3Complete;
    public bool level4Complete;
    public bool level5Complete;
    public bool level6Complete;

   
    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        sceneName = "MenuScene";
        currScene = SceneManager.GetActiveScene().name;

        currLevel = SceneManager.GetActiveScene().buildIndex;

       

        GameObject[] levelCheckers = GameObject.FindGameObjectsWithTag("Tracker");

        if (levelCheckers.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        if(currLevel == 2)
        {
            level1Complete = true;
        }
        if (currLevel == 3)
        {
            level2Complete = true;
        }
        if (currLevel == 4)
        {
            level3Complete = true;
        }
        if (currLevel == 5)
        {
            level4Complete = true;
        }
        if (currLevel == 6)
        {
            level5Complete = true;
        }






    }

  /*  void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {

        if (currScene != sceneName)
        {


            SaveSystem.SaveLevelProgress(this);
            Debug.Log("OnSceneLoaded: " + scene.name);
            Debug.Log(mode);
        }
    }*/

        public void SavePlayer()
    {
        SaveSystem.SaveLevelProgress(this);
    }

    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();

        level1Complete = data.level1Complete;
        level2Complete = data.level2Complete;
        level3Complete = data.level3Complete;
        level4Complete = data.level4Complete;
        level5Complete = data.level5Complete;
        level6Complete = data.level6Complete; 


    }




}
