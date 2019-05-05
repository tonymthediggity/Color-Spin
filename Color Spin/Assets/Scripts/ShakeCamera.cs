using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{

    //FIX THIS ASAP

    public GameObject player;
    public float duration;
    public Vector3 originalPos;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        duration = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (player.GetComponent<ColorCheck>().shouldShake && duration == 0)
        {
            originalPos = transform.position;
            duration += Time.deltaTime;
            Shake();
        }

        if (duration > 1)
        {
            duration = 0;
            transform.position = new Vector3(0, 0, -10);
        }
        
    }

    void Shake()
    {
        transform.position = Random.insideUnitSphere * 100;
        
    }
}
