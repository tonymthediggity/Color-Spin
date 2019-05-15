using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntryPortal : MonoBehaviour
{
    public GameObject pcb;
    public Vector3 oldVelocity;
    public Vector3 newVelocity;
    public GameObject[] portals;
    // Start is called before the first frame update
    void Start()
    {
        pcb = GameObject.FindGameObjectWithTag("Player");
        portals = GameObject.FindGameObjectsWithTag("ExitPortal");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        oldVelocity = pcb.GetComponent<Rigidbody>().velocity;
        collision.transform.position = portals[0].transform.position;
        newVelocity = oldVelocity;
        pcb.GetComponent<Rigidbody>().velocity = newVelocity;
    }
}
