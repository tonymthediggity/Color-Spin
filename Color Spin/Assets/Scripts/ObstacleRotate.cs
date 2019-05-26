using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRotate : MonoBehaviour
{
    public int rotDir;
    public int rotateSpeed;
    public int moveDirLR;
    public int moveDirUD;
    public int moveSpeedX;
    public int moveSpeedY;
    public Rigidbody myBody;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody>();
        myBody.velocity =  new Vector3( moveSpeedX * Time.deltaTime, moveSpeedY * Time.deltaTime, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
            transform.Rotate(0,0,rotateSpeed * rotDir * Time.deltaTime);

        Vector3 v = myBody.velocity;
        v = v.normalized;
        v *= moveSpeedX;
        myBody.velocity = v;





    }

    private void OnCollisionEnter(Collision other)
    {
        
    }
}
