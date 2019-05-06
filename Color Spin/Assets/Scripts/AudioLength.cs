using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLength : MonoBehaviour
{
    public AudioSource mySource;
    public AudioClip myClip;
    // Start is called before the first frame update
    void Start()
    {
        mySource = GetComponent<AudioSource>();
        myClip = mySource.GetComponent<AudioClip>();

        Debug.Log("Clip length is " + mySource.clip.length);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
