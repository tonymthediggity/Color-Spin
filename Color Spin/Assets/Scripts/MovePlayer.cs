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
    }

    
    void Update()
    {

        mainCam = Camera.main;
        



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

        

        if (Input.GetMouseButton(0) /*&& playerCannonBallClone == null*/)
        {
            clickPos.transform.position = mainCam.ScreenToWorldPoint(Input.mousePosition);
            transform.up = clickPos.transform.position - transform.position;

            
        }

        if (Input.GetMouseButtonUp(0) && playerCannonBallClone == null)
        {
            Shoot();
            numberOfShots++;
        }






        Vector3 forward = myFP.transform.TransformDirection(Vector3.forward);
        Debug.DrawRay(myFP.transform.position, forward * 100, Color.red );

        

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
