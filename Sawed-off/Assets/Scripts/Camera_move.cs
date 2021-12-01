using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_move : MonoBehaviour
{
    //Camera boundary movement code gotten from N3K EN
    public float BoundaryX;
    public float BoundaryY;

    public Transform player;

    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 delta = Vector3.zero;

        float dx = player.position.x - transform.position.x;
        // X Axis
        if(dx > BoundaryX || dx < -BoundaryX)
        {
            if(transform.position.x < player.position.x)
            {
                delta.x = dx - BoundaryX;
            }
            else
            {
                delta.x = dx + BoundaryX;
            }
        }

        float dy = player.position.y - transform.position.y;
        // X Axis
        if (dy > BoundaryY || dy < -BoundaryY)
        {
            if (transform.position.y < player.position.y)
            {
                delta.y = dy - BoundaryY;
            }
            else
            {
                delta.y = dy + BoundaryY;
            }
        }

        //move the camera
        transform.position = transform.position + delta;
    }
}
