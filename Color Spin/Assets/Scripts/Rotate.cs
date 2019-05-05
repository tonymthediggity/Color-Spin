using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    // Start is called before the first frame update
    Vector3 torque;

    public GameObject hasScore;

    void Awake()
    {
        hasScore = GameObject.FindGameObjectWithTag("Player");


        torque.x = Random.Range(-200, 200);
        torque.y = Random.Range(-200, 200);
        torque.z = Random.Range(-200, 200);
        GetComponent<ConstantForce>().torque = torque;

        GetComponent<Rigidbody>().velocity = new Vector3(0, -1 * hasScore.GetComponent<ColorCheck>().score, 0);
        Debug.Log("Score is " + hasScore.GetComponent<ColorCheck>().score);

    }
}
