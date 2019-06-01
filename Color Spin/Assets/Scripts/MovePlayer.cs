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
    public LineRenderer theLine;
    public int lineCount = 0;
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
    public Vector3 newDir;
    public GameObject newDirObj;







    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        clickPos = GameObject.Find("ClickPos");
        bodyCol = GetComponentInChildren<SphereCollider>();
        bodyCol.enabled = false;
        theLine = GetComponent<LineRenderer>();
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
            Vector3 cPos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            clickPos.transform.position = new Vector3(cPos.x, cPos.y, 0);




            

             transform.up = clickPos.transform.position - transform.position;






            /*
            RaycastHit hit;
            
            //initial ray
            Debug.DrawRay(transform.position, transform.up * 100f, Color.green);
            //initial ray
            if(Physics.Raycast(transform.position, transform.up, out hit, 100f))
            {
                theLine.enabled = true;
                theLine.SetPosition(0, transform.position);
                theLine.SetPosition(1, hit.point);
                theLine.SetPosition(2, hit.point);
                newDir = Vector3.Reflect(transform.up, hit.normal);
                
                
                Debug.DrawRay(hit.point, newDir * 100f, Color.blue); //second ray




                if (Physics.Raycast(hit.point, newDir, out hit, 100f))
                {
                    theLine.positionCount = 4;
                    theLine.SetPosition(3, hit.point);
                    newDir = Vector3.Reflect(hit.point, transform.up);
                    Debug.DrawRay(hit.point, newDir * 100f, Color.red);
                   




                    if (Physics.Raycast(hit.point, newDir, out hit, 100f))
                    {
                        theLine.positionCount = 5;
                        theLine.SetPosition(4, hit.point);
                        newDir = Vector3.Reflect(hit.point, transform.up);
                        Debug.DrawRay(hit.point, newDir * 100f, Color.magenta);

                        

                    }
                }



            }*/
            

            
            







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
