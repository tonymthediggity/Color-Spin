using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoRandom : MonoBehaviour
{
    public VideoPlayer myPlayer;
    public VideoClip startClip;
    public VideoClip randomClip;
    public VideoClip[] allVideos;
    public LevelLoadUI levelHandler;
    public bool shouldLoadVideo = false;


    // Start is called before the first frame update
    void Start()
    {
        myPlayer = GetComponent<VideoPlayer>();
        levelHandler = GameObject.Find("LevelLoadUI").GetComponent<LevelLoadUI>();
       allVideos = Resources.LoadAll<VideoClip>("Videos");

       
            PlayRandomVideo();
            shouldLoadVideo = false;
      
    }

    // Update is called once per frame
    void Update()
    {
        

       
    }

    void PlayRandomVideo()
    {
        int index = Random.Range(0, allVideos.Length);
        randomClip = allVideos[index];
        myPlayer.clip = randomClip;
        myPlayer.Play();


    }
}
