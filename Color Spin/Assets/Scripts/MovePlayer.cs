using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovePlayer : MonoBehaviour
{

    public SphereCollider bodyCol;
    public GameObject myFP;
    public Vector3 myFpPos;
    public LineRenderer aimLine;
    public bool isAiming;
    public int aimSensitivity;
    public GameObject myCannonBallPrefab;
    public int numberOfShots;
    public Text shotText;
    public bool canFire;
    public float timeTilFireAgain;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        canFire = true;
        isAiming = false;
        bodyCol = GetComponentInChildren<SphereCollider>();
        bodyCol.enabled = false;
        aimLine = GetComponent<LineRenderer>();
    }
    void Update()
    {

        shotText.text = "Shots " + numberOfShots;
        myFpPos = myFP.transform.position;
        if (!isAiming)
        {
            var v3 = Input.mousePosition;

            v3 = Camera.main.ScreenToWorldPoint(v3);
            v3.z = 0;

            transform.position = v3;
        }

        if (Input.GetMouseButton(0))
        {
            isAiming = true;
            transform.Rotate(0, 0, Input.GetAxis("Mouse X") * aimSensitivity);
            

            

        }
        else
        {
            isAiming = false;
        }

        if (Input.GetMouseButtonUp(1) && canFire)
        {
            Shoot();
            numberOfShots++;

        }

        if(canFire == false)
        {
            timeTilFireAgain += Time.deltaTime;
        }

        if(timeTilFireAgain >= 3)
        {
            canFire = true;
            timeTilFireAgain = 0;
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
        canFire = false;
        GameObject obj = (GameObject)Instantiate(myCannonBallPrefab, myFpPos, myFP.transform.rotation);
        obj.GetComponent<Rigidbody>().velocity = myFP.transform.forward * 300;
        
        
    }
}
