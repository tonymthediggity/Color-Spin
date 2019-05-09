using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonBall : MonoBehaviour
{
    public Rigidbody myBody;

    public float despawnTimer;
    public bool despawnTimerActive;
    public GameObject destroyParticles;
    public CannonBallVel cannonBall;
    public int score;
    public AudioSource myAudio;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        myAudio = GetComponent<AudioSource>();
        despawnTimer = 0;
        
        
    }

    // Update is called once per frame
    void Update()
    {
      
        despawnTimer += Time.deltaTime;

        
        
        

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
        }
    }
}
