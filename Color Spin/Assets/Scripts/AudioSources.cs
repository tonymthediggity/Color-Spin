using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSources : MonoBehaviour
{

    public AudioSource enemyDestroySound;
    public AudioSource playerHitSound;
    public AudioSource[] sounds;




    // Start is called before the first frame update
    private void Start()
    {
        sounds = GetComponents<AudioSource>();
        enemyDestroySound = sounds[0];
        playerHitSound = sounds[1];
    }


    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
