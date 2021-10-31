using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float shot_force;
    public float rotation_force;
    Vector3 mousePos;
    Vector3 PointmousePos;
    Vector3 launchdirect; 
    public Camera cam;

    public GameObject launchPoint;//The shotgun where we get our flat launch power from, and is the acutal shot gun on the model.
    public GameObject pivot;// the empty game object that the launch point is attatched to allowing it to rotate.
    private Vector3 pointerpos;

    public Transform boi;
    public float radius;

    private bool flip; // The flip back to 0 will occur if true
    private bool fired; // A shot was fired and the conditions with that are then set
    private int ammo;

    private Rigidbody2D rg2d;
    private BoxCollider2D boxcld;

    //Bunch of stuff for checking if the player is touching the ground
    public LayerMask whatIsGround;
    public float CheckRadius;
    private bool isGrounded;
    public Transform groundCheck;
    public float waitTime; //Time the player waits after fireing to flip up
    private float timer; //Actual timer to keep time
    
    // Start is called before the first frame update
    void Start()
    {
        timer = waitTime;
        pivot.transform.position = transform.position;
        rg2d = GetComponent<Rigidbody2D>();
        boxcld = GetComponent<BoxCollider2D>();
        ammo = 2;
    }

    // Update is called once per frame
    void Update()
    {

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, CheckRadius, whatIsGround);
        if(isGrounded == true)
        {
            if((timer != 0 || timer > 0) && Mathf.Abs(rg2d.velocity.x) < 0.001f && Mathf.Abs(rg2d.velocity.y) < 0.001f)
            {
                timer -= Time.deltaTime;
            }
            //Debug.Log("Timer = " + timer);
        }

        Vector3 Pointermouse = cam.ScreenToWorldPoint(Input.mousePosition);

        //New point idea based on code by GameDevHQ
        Vector3 point = Pointermouse - transform.position; // Directin = destination - source

        //float angle = Mathf.Acos((Vector3.Dot(point, Pointermouse) / (origin.magnitude * Pointermouse.magnitude))) * Mathf.Rad2Deg;
        float angle = Mathf.Atan2(point.y, point.x) * Mathf.Rad2Deg - 90;

        Debug.DrawRay(transform.position, point, Color.red);

        //define rotation along a specific axis using angle
        Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
        //slerp from our current rotation to the new specific rotation to the new specific rotation
        pivot.transform.rotation = Quaternion.Slerp(pivot.transform.rotation, angleAxis, Time.deltaTime * 50);
        //updating variables

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //launchdirection is the point the player gets launched to, and shot_force is negative to make sure you are going opposite of the mouse
        launchdirect = ((launchPoint.transform.position - transform.position)) * -shot_force; //Need to subtract the player position from launchPoint to get its child position
   
        if (Input.GetButtonDown("Fire1") && ammo != 0)
        {
            Debug.Log("Launchdirection = " + launchdirect);
            rg2d.velocity = launchdirect;

            //Sets the recoil rotation
            float rotate_angle = Mathf.Atan2(launchdirect.y, launchdirect.x) * Mathf.Rad2Deg - 90;

            Debug.Log("Angle = " + rotate_angle);

            if (angle < 90 && angle > 0)
            {
                rg2d.AddTorque( (Mathf.Deg2Rad * rotate_angle) * -rotation_force);
            }
            else if (angle < 0 && angle > -90)
            {
                rg2d.AddTorque((Mathf.Deg2Rad * rotate_angle) * -rotation_force);
            }
            else { rg2d.AddTorque((Mathf.Deg2Rad * rotate_angle) * rotation_force); }

            fired = true; //a shot was taken so now the playe is commited to physics since this is true
            timer = waitTime; //set the ground timer as a shot has been fired and it is reset
            --ammo; //fire a shot
        }

        //Flip up and reload
        if (timer < 0 && fired == true) //conditions are that a shot was fired and the player was on the ground for the waitTime amount
        {
            rg2d.velocity = Vector3.up * 10; //Pops player up so the rotation can occur and because i think it looks nice
      
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, 360 * Time.deltaTime); //begins the flip that continues in the next flip
            flip = true;
        }
        if (flip == true) //Best way i could get the smooth rotation and flip to occur
        {
           
            if (transform.rotation == Quaternion.identity)
            {
                flip = false;
                fired = false;
                ammo = 2;
            }
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, 360 * Time.deltaTime);

        }
    }
}
