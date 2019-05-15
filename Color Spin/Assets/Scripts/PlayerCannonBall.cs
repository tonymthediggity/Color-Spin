using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonBall : MonoBehaviour
{
    public Rigidbody myBody;
    public float headingX;
    public float headingY;

    public float despawnTimer;
    public bool despawnTimerActive;
    public GameObject destroyParticles;
    public CannonBallVel cannonBall;
    public int score;
    public AudioSource myAudio;

    public Vector3 oldVelocity;
    public Vector3 newVelocity;
    public GameObject entryPortal;
    public GameObject exitPortal;

    // Start is called before the first frame update
    void Awake()
    {
        entryPortal = GameObject.FindGameObjectWithTag("EntryPortal");
        exitPortal = GameObject.FindGameObjectWithTag("ExitPortal");
        myBody = GetComponent<Rigidbody>();
        myAudio = GetComponent<AudioSource>();
        despawnTimer = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
      
        despawnTimer += Time.deltaTime;
        headingX = myBody.velocity.x;
        headingY = myBody.velocity.y;

        

        
        
        

        if(Input.GetMouseButtonDown(1))
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
            myAudio.Play();
            RandomVelocityTweak();
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("EntryPortal"))
        {
            oldVelocity = myBody.velocity;
            transform.position = exitPortal.transform.position;
            newVelocity = oldVelocity;
            myBody.velocity = newVelocity;
        }

        
    }

    private void RandomVelocityTweak()
    {
        //TODO: Keep angular trajectory when bouncing to prevent infinite bounce loops using headingX and headingY!!!!
        /*
        if (headingX > 0)
        {
            Vector3 velocityTweak = new Vector3(Random.Range(0f, 0.5f), myBody.velocity.y, 0);
            //add velocity tweak to velocity
            myBody.velocity += velocityTweak;

        }
        if (headingX <0 )
        {
            //create random velocity tweak from 0 - 0.3f
            Vector3 velocityTweak = new Vector3(Random.Range(0f, 0.5f), myBody.velocity.y, 0);
            //add velocity tweak to velocity
            myBody.velocity.x -= velocityTweak;
        }

        if (headingY > 0)
        {
            //create random velocity tweak from 0 - 0.3f
            Vector3 velocityTweak = new Vector3(myBody.velocity.x, Random.Range(0f, 12), 0);
            //add velocity tweak to velocity
            myBody.velocity += velocityTweak;
        }

        if (headingX < 0)
        {
            //create random velocity tweak from 0 - 0.3f
            Vector3 velocityTweak = new Vector3(myBody.velocity.x, Random.Range(0f, 12), 0);
            //add velocity tweak to velocity
            myBody.velocity -= velocityTweak;
        }*/

    }
}
