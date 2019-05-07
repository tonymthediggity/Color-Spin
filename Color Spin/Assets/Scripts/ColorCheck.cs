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


    public AudioSource audio1;
    public AudioSource audio2;

    public GameObject[] cubes;
    public GameObject currentCube;
    public GameObject colorManager;
    public MeshRenderer cubeRend;

    public Text scoreText;
    public Text healthText;


    public GameObject gameOverPanel;

    public int score = 0;
    public GameObject scoreHolder;

    public bool colorsMatch = false;

    public bool shouldShake = false;

    // Start is called before the first frame update
    void Start()
    {
        colorManager = GameObject.FindGameObjectWithTag("ColorManager");
        healthBar = GetComponentInChildren<Slider>();
        gameOverPanel.SetActive(false);
        myRend = GetComponent<MeshRenderer>();
        myRend.material.color = colorManager.GetComponent<ColorManager>().currColor;



        

        
        
    }

    // Update is called once per frame
    void Update()
    {

        
        cubes = GameObject.FindGameObjectsWithTag("CannonBall");
        myRend.material.color = colorManager.GetComponent<ColorManager>().currColor;


        if (cubes.Length != 0)
        {
            

            currentCube = cubes[0];
            cubeRend = currentCube.GetComponent<MeshRenderer>();
            scoreHolder = GameObject.Find("PlayerCannonBall");
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
       

        if (destroyTimer > 1)
        {
            
            destroyTimer = 0;
        }

        if(playerHitTimer > 1)
        {
            
            playerHitTimer = 0;
        }


        
        



        


        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(colorsMatch == true)
        {
           
            audio1.Play();

            
            Destroy(collision.gameObject);

            score += scoreHolder.GetComponent<PlayerCannonBall>().score;


            

            


        }
        else if (colorsMatch == false)
        {
            audio2.Play();


            Destroy(collision.gameObject);
            

            playerHealth -= 5;
            

        } 


    }
    


 
}
