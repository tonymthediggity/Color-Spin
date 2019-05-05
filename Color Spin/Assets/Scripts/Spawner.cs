using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject boxPrefab;
    public float spawnTimer;
    // Start is called before the first frame update
    void Start()
    {
        spawnTimer = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime;

        if(spawnTimer >= 3)
        {
            SpawnBox();
            transform.position = new Vector3(Random.Range(-40, 40), 35, 0);
        }

        
    }

    void SpawnBox()
    {
        Instantiate(boxPrefab, transform.position, transform.rotation);
        
        spawnTimer = 0;
    }
}
