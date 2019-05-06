using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCannonBall : MonoBehaviour
{

    public float despawnTimer;
    public bool despawnTimerActive;
    public GameObject destroyParticles;
    public CannonBallVel cannonBall;
    public int score;

    // Start is called before the first frame update
    void Awake()
    {
        despawnTimer = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

        if (despawnTimerActive)
        {
            despawnTimer += Time.deltaTime;
        }
        

        if(despawnTimer >= 3)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("CannonBall"))
        {
            Destroy(other.gameObject);
            despawnTimerActive = true;

            
        }
    }
}
