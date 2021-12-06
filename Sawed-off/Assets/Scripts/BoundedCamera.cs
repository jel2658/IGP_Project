using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundedCamera : MonoBehaviour
{

    //Code gotten from N3K EN bounds Camera tutorial

    public float speed; 

    private float boundsX = 2.0f;
    private float boundsY = 1.5f;
    public Transform LookAt; //The players transform

    private Vector3 desiredposition;

    // Update is called once per frame
    private void LateUpdate()
    {
        
        Vector3 delta = Vector3.zero;

        float dx = LookAt.position.x - transform.position.x;
        //X axis
        if(dx > boundsX || dx < -boundsX)
        {
            if(transform.position.x < LookAt.position.x)
            {
                delta.x = dx - boundsX;
            }
            else
            {
                delta.x = dx + boundsX;
            }
        }


        float dy = LookAt.position.y - transform.position.y;
        if (dy > boundsY || dy < -boundsY)
        {
            if (transform.position.y < LookAt.position.y)
            {
                delta.y = dy - boundsY;
                
            }
            else
            {
                delta.y = dy + boundsY;
                
            }
        }
   
        //move Camera
        desiredposition = transform.position + delta;
        //if (desiredposition.y < 3) { desiredposition.y = 3; }
        transform.position = Vector3.Lerp(transform.position, desiredposition, speed);
        
    }
}
