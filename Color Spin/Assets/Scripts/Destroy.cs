using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{

    public GameObject player;

    public AudioSource playerHitSound;
    public GameObject playerHitParticles;




    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        playerHitSound.Play();
        



        
        playerHitParticles.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, -8);
        playerHitParticles.SetActive(true);
        Destroy(collision.gameObject);
        player.GetComponent<ColorCheck>().playerHealth -= 5;
  


        Destroy(collision.gameObject);
    }
}
