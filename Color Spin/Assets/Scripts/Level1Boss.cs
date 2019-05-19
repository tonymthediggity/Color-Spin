using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1Boss : MonoBehaviour
{
    public GameObject cannonBallPrefab;
    public float spawnTimer;
    public GameObject[] myCB;
    public bool levelStart;



    public int startVelRand;
    public MeshRenderer myRend;
    public GameObject colorManager;
    public Rigidbody myBody;
    public int speed;

    // Start is called before the first frame update
    void Awake()
    {
        levelStart = true;
        
        startVelRand = Random.Range(1, 4);
        speed = 125;
        myBody = GetComponent<Rigidbody>();
        if (startVelRand == 1)
        {
            myBody.velocity = new Vector3(speed, speed, 0);
        }
        if (startVelRand == 2)
        {
            myBody.velocity = new Vector3(speed, -speed, 0);
        }
        if (startVelRand == 3)
        {
            myBody.velocity = new Vector3(-speed, speed, 0);
        }
        if (startVelRand == 4)
        {
            myBody.velocity = new Vector3(-speed, -speed, 0);
        }



        myRend = GetComponent<MeshRenderer>();
        colorManager = GameObject.Find("ColorManager");

        GameObject cBP = Instantiate(cannonBallPrefab, transform.position, transform.rotation);
        cBP.GetComponent<Rigidbody>().AddForce(100, 43, 0);
        GameObject cBP2 = Instantiate(cannonBallPrefab, transform.position, transform.rotation);
        cBP.GetComponent<Rigidbody>().AddForce(32, 76, 0);
        GameObject cBP3 = Instantiate(cannonBallPrefab, transform.position, transform.rotation);
        cBP.GetComponent<Rigidbody>().AddForce(100, 100, 0);


    }

    // Update is called once per frame
    void Update()
    {
        myRend.material.color = colorManager.GetComponent<ColorManager>().currColor;
        spawnTimer += Time.deltaTime;
        myCB = GameObject.FindGameObjectsWithTag("CannonBall");

        if (spawnTimer > 3)
        {
            Spawn();
            spawnTimer = 0;

        }

        if(myCB.Length >= 1)
        {
            levelStart = false;
        }

        Vector3 v = myBody.velocity;
        v = v.normalized;
        v *= speed;
        myBody.velocity = v;

        if(myCB.Length <= 0 && levelStart == false)
        {
            Destroy(this.gameObject);
        }
    }

 

    public void Spawn()
    {
       GameObject cBP = Instantiate(cannonBallPrefab, transform.position, transform.rotation);
        cBP.GetComponent<Rigidbody>().AddForce(100, 100, 0);
    }
}
