using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{

    public int rotateSpeed;

    // Start is called before the first frame update
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.Rotate(0,0,rotateSpeed * Time.deltaTime);
        



    }

    private void OnCollisionEnter(Collision other)
    {
        if (!other.gameObject.CompareTag("PlayerCannonBall"))
        {
            rotateSpeed = -rotateSpeed;
        }
    }
}
