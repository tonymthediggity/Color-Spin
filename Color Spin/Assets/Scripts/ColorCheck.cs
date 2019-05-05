using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCheck : MonoBehaviour
{

    public Color myColor;

    public float playerHealth;
    public Slider healthBar;

    public MeshRenderer myRend;

    public float destroyTimer;
    public float playerHitTimer;
    public bool enableDestroyParticles = false;
    public bool enablePlayerHitParticles = false;

    public AudioSource audio1;
    public AudioSource audio2;

    public GameObject[] cubes;
    public GameObject currentCube;
    public GameObject colorManager;
    public MeshRenderer cubeRend;

    public Text scoreText;
    public Text healthText;

    public GameObject destroyParticles;
    public GameObject playerHitParticles;

    public GameObject gameOverPanel;

    public int score = 0;
    public Score scoreHolder;

    public bool colorsMatch = false;

    public bool shouldShake = false;

    // Start is called before the first frame update
    void Start()
    {
        
        healthBar = GetComponentInChildren<Slider>();
        gameOverPanel.SetActive(false);
        myRend = GetComponent<MeshRenderer>();
        myRend.material.color = colorManager.GetComponent<ColorManager>().currColor;

        destroyParticles = GameObject.Find("Destroy Particles");
        destroyParticles.SetActive(false);

        playerHitParticles = GameObject.Find("PlayerHitParticles");
        playerHitParticles.SetActive(false);

        

        
        
    }

    // Update is called once per frame
    void Update()
    {

        scoreText.text = "Score:  " + score;
        healthText.text = "Health: " + playerHealth;
        cubes = GameObject.FindGameObjectsWithTag("CannonBall");
        myRend.material.color = colorManager.GetComponent<ColorManager>().currColor;


        if (cubes.Length != 0)
        {
            

            currentCube = cubes[0];
            cubeRend = currentCube.GetComponent<MeshRenderer>();
            scoreHolder = currentCube.GetComponent<Score>();
            myRend.material.color = cubeRend.material.color;

            if (myRend.material.color == cubeRend.material.color)
            {
                colorsMatch = true;
            }
            else
            {
                colorsMatch = false;
            }
        }

        myColor = myRend.material.color;

       

        

        // healthBar.value = playerHealth / 30;
        if (enableDestroyParticles)
        {
            destroyTimer += Time.deltaTime;
        }

        if (enablePlayerHitParticles)
        {
            playerHitTimer += Time.deltaTime;
        }

        if (destroyTimer > 1)
        {
            destroyParticles.SetActive(false);
            enableDestroyParticles = false;
            destroyTimer = 0;
        }

        if(playerHitTimer > 1)
        {
            playerHitParticles.SetActive(false);
            enablePlayerHitParticles = false;
            playerHitTimer = 0;
        }


        
        



        


        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(colorsMatch == true)
        {
            enableDestroyParticles = true;
            destroyParticles.SetActive(true);
            destroyParticles.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, -8);

            audio1.Play();

            
            Destroy(collision.gameObject);

            score += scoreHolder.score;


            

            


        }
        else if (colorsMatch == false)
        {
            audio2.Play();

            enablePlayerHitParticles = true;
            playerHitParticles.transform.position = new Vector3(collision.transform.position.x, collision.transform.position.y, -8);
            playerHitParticles.SetActive(true);
            Destroy(collision.gameObject);
            

            playerHealth -= 5;
            

        }


    }
    


 
}
