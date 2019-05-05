using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour
{

    
    void Update()
    {
        

        var v3 = Input.mousePosition;
        
        v3 = Camera.main.ScreenToWorldPoint(v3);
        v3.z = 0;

        transform.position = v3;

        /* Vector3 mouse = Input.mousePosition;
         Ray castPoint = Camera.main.ScreenPointToRay(mouse);
         RaycastHit hit;
         if (Physics.Raycast(castPoint, out hit, Mathf.Infinity, hitLayers))
         {
             transform.position = hit.point;
         }*/
    }
}
