using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyParticle : MonoBehaviour
{

    public float timer;
    // Start is called before the first frame update
    void Awake()
    {
        timer = 0;

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if(timer >= 3.3)
        {
            Destroy(this.gameObject);
        }
    }
}
