using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonBall : MonoBehaviour
{
    public Rigidbody myBody;
    public float headingX;
    public float headingY;
    public int bounceCount = 0;

    public float despawnTimer;
    public bool despawnTimerActive;
    public GameObject destroyParticles;
    public CannonBallVel cannonBall;
    public int score;
    public AudioSource myAudio;

    public float xVel;
    public float yVel;
    public Vector3 localVel;
    public bool headingLeft;
    public bool headingRight;
    public bool headingUp;
    public bool headingDown;

    public Vector3 oldVelocity;
    public Vector3 newVelocity;
    public GameObject entryPortal;
    public GameObject exitPortal;
    public float speed = 300;

    // Start is called before the first frame update
    void Awake()
    {
        entryPortal = GameObject.FindGameObjectWithTag("EntryPortal");
        exitPortal = GameObject.FindGameObjectWithTag("ExitPortal");
        myBody = GetComponent<Rigidbody>();
        myAudio = GetComponent<AudioSource>();
        despawnTimer = 0;
        speed = 300;
        
        
    }

    // Update is called once per frame
    void Update()
    {
        yVel = Mathf.Abs(myBody.velocity.y);
        xVel = Mathf.Abs(myBody.velocity.x);
        localVel = transform.InverseTransformDirection(myBody.velocity);
        despawnTimer += Time.deltaTime;
        headingX = myBody.velocity.x;
        headingY = myBody.velocity.y;

        if(bounceCount >= 7)
        {
            Destroy(this.gameObject);
        }

        /*if(localVel.x > 0 && !headingLeft)
        {
            headingRight = true;
        }
        if (headingRight)
        {
            headingLeft = false;
        }
        
       
        if (localVel.x < 0 && !headingRight)
        {
            headingLeft = true;
        }
        if (headingLeft)
        {
            headingRight = false;
        }
       


       /* if (localVel.y > 0 && !headingDown)
        {
            headingUp = true;
        }
        if (headingUp)
        {
            headingDown = false;
        }*/

       


       /* if (localVel.y < 0 && !headingUp)
        {
            headingDown = true;
        }
        if (headingDown)
        {
            headingUp = false;
        }*/

        




        Vector3 v = myBody.velocity;
        v = v.normalized;
        v *= speed;
        myBody.velocity = v;



        if (Input.GetMouseButtonDown(0))
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {

        
        if (other.collider.CompareTag("CannonBall"))
        {
            Destroy(other.gameObject);
            
            myAudio.Play();

            
        }
        if (!other.collider.CompareTag("CannonBall"))
        {
            bounceCount++;
            myAudio.Play();
          /*  if(xVel != 300 && headingRight)
            {
                myBody.AddForce(new Vector3(1000, 0, 0));
            }

            if (xVel != 300 && headingLeft)
            {
                myBody.AddForce(new Vector3(-1000, 0, 0));
            }

            if (yVel != 300 && headingUp)
            {
                myBody.AddForce(new Vector3(0, 1000, 0));
            }
            if (yVel != 300 && headingDown)
            {
                myBody.AddForce(new Vector3(0, -1000, 0));
            }
            */

        }

        


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EntryPortal"))
        {
            bounceCount = 0;
            oldVelocity = myBody.velocity;
            transform.position = exitPortal.transform.position;
            newVelocity = oldVelocity;
            myBody.velocity = newVelocity;
        }

        
    }
   

 


}
