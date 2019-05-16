using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceLine : MonoBehaviour
{
    public class RaycastTest : MonoBehaviour
    {

        //this game object's Transform
        private Transform goTransform;
        //the attached line renderer
        public LineRenderer lineRenderer;

        //a ray
        private Ray ray;
        //a RaycastHit variable, to gather informartion about the ray's collision
        private RaycastHit hit;
        //reflection direction
        private Vector3 direction;
        //the number of reflections
        public int nReflections = 2;
        //max length
        public float maxLength = 400f;
        //the number of points at the line renderer
        private int numPoints;
        //private int pointCount;
        void Awake()
        {
            //get the attached Transform component  
            goTransform = GetComponent<Transform>();
            //get the attached LineRenderer component  
            lineRenderer = GetComponent<LineRenderer>();
        }
        void Update()
        {
            //clamp the number of reflections between 1 and int capacity  
            nReflections = Mathf.Clamp(nReflections, 1, nReflections);
            ray = new Ray(goTransform.position, goTransform.right);
            //start with just the origin
            lineRenderer.positionCount = 1;
            lineRenderer.SetPosition(0, goTransform.position);
            float remainingLength = maxLength;
            //bounce up to n times
            for (int i = 0; i < nReflections; i++)
            {
                // ray cast
                if (Physics.Raycast(ray.origin, ray.direction, out hit, remainingLength))
                {
                    Debug.Log("Hit");
                    //we hit, update line renderer
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, hit.point);
                    // update remaining length and set up ray for next loop
                    remainingLength -= Vector3.Distance(ray.origin, hit.point);
                    ray = new Ray(hit.point, Vector3.Reflect(ray.direction, hit.normal));
                    // break loop if we don't hit a Mirror
                    if (hit.collider)
                        break;
                }
                else
                {
                    // We didn't hit anything, draw line to end of ramainingLength
                    lineRenderer.positionCount += 1;
                    lineRenderer.SetPosition(lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
                    break;
                }
            }
        }


    }
}