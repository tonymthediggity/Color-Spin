using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossShield : MonoBehaviour
{

    public GameObject boss;
    public Vector3 axis;
    // Start is called before the first frame update
    void Start()
    {
        boss = GameObject.FindGameObjectWithTag("Boss");
        
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
