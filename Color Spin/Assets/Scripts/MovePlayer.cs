using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{
    public Vector3 playerPos;
    public SphereCollider bodyCol;
    public GameObject myFP;
    public Vector3 myFpPos;
    public LineRenderer aimLine;
    public GameObject playerCannonBallClone;
    public int aimSensitivity;
    public GameObject myCannonBallPrefab;
    public int numberOfShots;
    public Text shotText;
    public GameObject clickPos;
    public Vector3 mousePos;
    public Camera mainCam;
    public LevelLoadUI llScript;
    public GameObject aimBallPrefab;
    public Vector3 oldPos;
    public float timerTilMovePosAgain;
    public bool startTimer = false;
    public GameObject[] aimBalls;

    public bool rayHit = false;







    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        clickPos = GameObject.Find("ClickPos");
        bodyCol = GetComponentInChildren<SphereCollider>();
        bodyCol.enabled = false;
        aimLine = GetComponent<LineRenderer>();
        playerPos = GameObject.Find("PlayerPos").transform.position;
        transform.position = playerPos;
        llScript = GameObject.FindGameObjectWithTag("LevelLoadUI").GetComponent<LevelLoadUI>();
    }

    
    void Update()
    {

        mainCam = Camera.main;

        aimBalls = GameObject.FindGameObjectsWithTag("AimBall");
        





            playerCannonBallClone = GameObject.Find("PlayerCannonBall(Clone)");
        shotText.text = "Shots " + numberOfShots;
        myFpPos = myFP.transform.position;
        /*  if (!isAiming)
          {
              var v3 = Input.mousePosition;

              v3 = Camera.main.ScreenToWorldPoint(v3);
              v3.z = 0;

              transform.position = v3;
          }*/

        //  if (Input.GetMouseButton(0))
        // {

        // works   transform.Rotate(0, 0, -Input.GetAxis("Mouse X") * aimSensitivity);




        //  }
        //  else
        // {
        //     isAiming = false;
        // }

        if (Input.GetMouseButton(0))
        {
            clickPos.transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
            transform.up = clickPos.transform.position - transform.position;
            oldPos = transform.position;
            Transform refObject;

            RaycastHit hit2;
            
            Debug.DrawRay(transform.position, transform.up * 100f, Color.green);

            if(Physics.Raycast(transform.position, transform.up, out hit2, 100f))
            {
                
                
                Vector3 newDir = Vector3.Reflect(transform.up, hit2.normal);
                Debug.DrawRay(hit2.point, newDir * 100f, Color.green);
                RaycastHit hit3;
                

                if (Physics.Raycast(hit2.point, transform.up, out hit3, 100f ))
                {
                    Vector3 newDir1 = Vector3.Reflect(transform.up, hit3.normal);
                    Debug.DrawRay(hit3.point, newDir1 * 100f, Color.green);
                    
                }
            }
            







            /* if (Physics.Raycast(ray, out hit))
             {
                 //currentMovementDirection = Vector3.Reflect(currentMovementDirection, hit.normal);
             }
             /*  if (aimBalls.Length ==0)
               {
                   GameObject aimObj = (GameObject)Instantiate(aimBallPrefab, myFpPos, myFP.transform.rotation);
                   aimObj.GetComponent<Rigidbody>().velocity = myFP.transform.forward * 300;
               }
               if(Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0 && aimBalls.Length >=1)
               {
                   Destroy(aimBalls[0]);
               }*/


        }

        if (Input.GetMouseButton(0) /*&& playerCannonBallClone == null*/)
        {
            

            /*if (!GameObject.Find("AimBall(Clone)"))
            {
                GameObject aimObj = (GameObject)Instantiate(aimBallPrefab, myFpPos, myFP.transform.rotation);
                aimObj.GetComponent<Rigidbody>().velocity = myFP.transform.forward * 300;
            }*/
           




        }

        if (Input.GetMouseButtonUp(0) && playerCannonBallClone == null && llScript.levelEndContEnable == false && llScript.levelStartEnable == false)
        {
            
            transform.position = oldPos;
            Shoot();
            numberOfShots++;
        }






        Vector3 forward = myFP.transform.TransformDirection(Vector3.forward);
        //Debug.DrawRay(myFP.transform.position, forward * 100, Color.red );

        

        /* Vector3 mouse = Input.mousePosition;
         Ray castPoint = Camera.main.ScreenPointToRay(mouse);
         RaycastHit hit;
         if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))
         {
             transform.position = hit.point;
         }*/
    }
    public void Shoot()
    {
        
        GameObject obj = (GameObject)Instantiate(myCannonBallPrefab, myFpPos, myFP.transform.rotation);
        obj.GetComponent<Rigidbody>().velocity = myFP.transform.forward * 300;
        
        
    }

    
}
