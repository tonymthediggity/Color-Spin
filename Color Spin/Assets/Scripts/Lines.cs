using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    const int Infinity = 999;
    public Transform fp;
    int maxReflections = 100;
    int currentReflections = 0;

    [SerializeField]
    public Vector3 startPoint;
    public Vector3 direction;
    List<Vector3> Points;
    int defaultRayDistance = 100;
    LineRenderer lr;

    // Use this for initialization
    void Start()
    {
        Points = new List<Vector3>();
        lr = transform.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        fp = GameObject.FindGameObjectWithTag("FP").transform;
        startPoint = fp.transform.forward;
        RaycastHit hit;
        var hitData = Physics.Raycast(startPoint, (direction - startPoint).normalized, out hit, defaultRayDistance);

        currentReflections = 0;
        Points.Clear();
        Points.Add(startPoint);

        if (hitData)
        {
            ReflectFurther(startPoint, hit);
        }
        else
        {
            Points.Add(startPoint + (direction - startPoint).normalized * Infinity);
        }

        lr.positionCount = Points.Count;
        lr.SetPositions(Points.ToArray());
    }

    private void ReflectFurther(Vector3 origin, RaycastHit hitData)
    {
        if (currentReflections > maxReflections) return;

        Points.Add(hitData.point);
        currentReflections++;

        Vector3 inDirection = (hitData.point - origin).normalized;
        Vector3 newDirection = Vector3.Reflect(inDirection, hitData.normal);
        RaycastHit hit;

        var newHitData = Physics.Raycast(hitData.point + (newDirection * 0.0001f), newDirection * 100, out hit, defaultRayDistance);
        if (newHitData)
        {
            ReflectFurther(hitData.point, hit);
        }
        else
        {
            Points.Add(hitData.point + newDirection * defaultRayDistance);
        }
    }
}



