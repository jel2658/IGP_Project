using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float shot_force;
    Vector3 mousePos;
    Vector3 PointmousePos;
    Vector3 launchdirect;
    public Camera cam;

    public GameObject pointer;
    private Vector3 pointerpos;

    public float radius;

    private Rigidbody2D rg2d;
    private BoxCollider2D boxcld;
    // Start is called before the first frame update
    void Start()
    {
        pointer.transform.position = transform.position;
        rg2d = GetComponent<Rigidbody2D>();
        boxcld = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 Pointermouse = cam.WorldToScreenPoint(Input.mousePosition);
        Vector3 origin = cam.WorldToScreenPoint(transform.position);

        origin = (Input.mousePosition - origin);
      
        float angle = Mathf.Atan2(origin.y, origin.x) * Mathf.Rad2Deg;
   
        float pointer_x = (radius * (float)Mathf.Cos(angle)) + transform.position.x;
        float pointer_y = (radius * (float)Mathf.Sin(angle)) + transform.position.y;
       
        pointer.transform.position = new Vector2(pointer_x, pointer_y);
        
        //
        
        //updating variables
       
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        launchdirect = (mousePos - transform.position).normalized * shot_force;
        if (Input.GetButtonDown("Fire1"))
        {
            rg2d.velocity = launchdirect; //the acutal launch command
           // pointer.transform.position = transform.position;
            Debug.Log("mouse vector = " + launchdirect);
            Debug.Log("pointerMouse = " + Pointermouse);
            Debug.Log("Pointer pos = " + pointer.transform.position);
            Debug.Log("Player cords = " + transform.position);
            Debug.Log("origin = " + origin);
            Debug.Log("angle = " + angle);
            Debug.Log("pointer_x = " + pointer_x + " pointer_y = " + pointer_y);
            Debug.Log("final pos = " + new Vector2(pointer_x, pointer_y));
        }
    }
}
