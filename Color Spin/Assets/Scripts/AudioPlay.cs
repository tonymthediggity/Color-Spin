using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlay : MonoBehaviour
{
    public AudioClip startClip;
    public AudioClip randomClip;
    public AudioClip[] allMusic;
    public AudioSource mySource;
    // Start is called before the first frame update
    void Start()
    {
        mySource = GetComponent<AudioSource>();
       // startClip = Resources.Load<AudioClip>("Music/dTreeGoMP3");
        //mySource.PlayOneShot(startClip);

        allMusic = Resources.LoadAll<AudioClip>("Music");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!mySource.isPlaying)
        {
            PlayRandomTracK();
        }

        
    }

    void PlayRandomTracK()
    {
        int index = Random.Range(0, allMusic.Length);
        randomClip = allMusic[index];
        mySource.clip = randomClip;
        mySource.Play();

        
    }
}
