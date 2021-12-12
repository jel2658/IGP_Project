using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player : MonoBehaviour
{
    public float shot_force;
    public float rotation_force;
    public float moveSpeed;
    Vector3 mousePos;
    Vector3 PointmousePos;
    Vector3 launchdirect; 
    public Camera cam;

    public GameObject launchPoint;  //The shotgun where we get our flat launch power from, and is the acutal shot gun on the model.
    public GameObject pivot;        // the empty game object that the launch point is attatched to allowing it to rotate.
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
    public TMP_Text AmmoText;

    //pickup boolians
    private bool PumpAction;
    private bool GrenadeLauncher;
    public float GrenadePower;

    //The animatopn controller
    public Animator animator;

    //variables for platform types
    public float BounceForce;

    //For triggering sounds
    private PlayerSFX plsfx;
    int fsound; //fire sound
    int PAsound; //pump action sound
    int GLsound; //grenade launcher sound

    //switch guns
    SwitchGuns SG;//switch guns
    
    
    // Start is called before the first frame update
    void Start()
    {
        timer = waitTime;
        pivot.transform.position = transform.position;
        rg2d = GetComponent<Rigidbody2D>();
        boxcld = GetComponent<BoxCollider2D>();
        ammo = 2;
        PumpAction = false;
        plsfx = GetComponent<PlayerSFX>();
        fsound = 1;
        PAsound = 1;
        GLsound = 1;
        SG = GetComponent<SwitchGuns>();
    }

    // Update is called once per frame
    void Update()
    {

        AmmoText.text = "Ammo: " + ammo;

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

        //Debug.DrawRay(transform.position, point, Color.red); //debug for the mouse point

        //define rotation along a specific axis using angle
        Quaternion angleAxis = Quaternion.AngleAxis(angle, Vector3.forward);
        //slerp from our current rotation to the new specific rotation to the new specific rotation
        pivot.transform.rotation = Quaternion.Slerp(pivot.transform.rotation, angleAxis, Time.deltaTime * 50);
        //updating variables

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        //launchdirection is the point the player gets launched to, and shot_force is negative to make sure you are going opposite of the mouse
        launchdirect = ((launchPoint.transform.position - transform.position)) * -shot_force; //Need to subtract the player position from launchPoint to get its child position
   
        if (Input.GetButtonDown("Fire1") && ammo != 0 && GrenadeLauncher == false)
        {
            //triggering sound
            plsfx.Gunshot(fsound);
            fsound = Random.Range(1, 5); //chooses random number between 1 & 5 for what the next gunshot sound will be

            fired = true; //a shot was taken so now the playe is commited to physics since this is true

            rg2d.isKinematic = false; //Unfreezes the player character making it able to move and rotate
            rg2d.constraints = RigidbodyConstraints2D.None;
            Debug.Log("Launchdirection = " + launchdirect);
            rg2d.velocity = launchdirect;

            //Sets the recoil rotation
            float rotate_angle = Mathf.Atan2(launchdirect.y, launchdirect.x) * Mathf.Rad2Deg - 90;

            if (angle < 90 && angle > 0)
            {
                rg2d.AddTorque( (Mathf.Deg2Rad * rotate_angle) * -rotation_force);
            }
            else if (angle < 0 && angle > -90)
            {
                rg2d.AddTorque((Mathf.Deg2Rad * rotate_angle) * -rotation_force);
            }
            else { rg2d.AddTorque((Mathf.Deg2Rad * rotate_angle) * rotation_force); }

           
            timer = waitTime; //set the ground timer as a shot has been fired and it is reset
            --ammo; //fire a shot
        }

        //Grenade launcher fire
        if (Input.GetButtonDown("Fire1") && ammo != 0 && GrenadeLauncher == true)
        {

            //triggering sound
            plsfx.GLpickup(5);

            Debug.Log("Grenade fired");
            fired = true; //a shot was taken so now the playe is commited to physics since this is true

            rg2d.isKinematic = false; //Unfreezes the player character making it able to move and rotate
            rg2d.constraints = RigidbodyConstraints2D.None;
            rg2d.velocity = launchdirect * GrenadePower;

            //Sets the recoil rotation
            float rotate_angle = Mathf.Atan2(launchdirect.y, launchdirect.x) * Mathf.Rad2Deg - 90;

            if (angle < 90 && angle > 0)
            {
                rg2d.AddTorque((Mathf.Deg2Rad * rotate_angle) * -rotation_force);
            }
            else if (angle < 0 && angle > -90)
            {
                rg2d.AddTorque((Mathf.Deg2Rad * rotate_angle) * -rotation_force);
            }
            else { rg2d.AddTorque((Mathf.Deg2Rad * rotate_angle) * rotation_force); }

            
            timer = waitTime; //set the ground timer as a shot has been fired and it is reset
            --ammo; //fire a shot
            GrenadeLauncher = false;
        }


        //player movement
        if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1 && rg2d.velocity.y < 0.0001 && fired == false && flip == false)
        {
            transform.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0) * moveSpeed * Time.deltaTime;
            
        }
        //animation condition for right left walking
        if(fired == true)
        {
            animator.SetFloat("Horizontal", 0); //Sets it so no matter what if a shot was fired no walking animation can take place
        }
        else
        {
            animator.SetFloat("Horizontal", Input.GetAxisRaw("Horizontal")); 
        }
        

        //Flip up and reload
        if (timer < 0 && fired == true) //conditions are that a shot was fired and the player was on the ground for the waitTime amount
        {
            rg2d.AddForce(Vector3.up * 3, ForceMode2D.Impulse); //Pops player up so the rotation can occur and because i think it looks nice
      
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, 360 * Time.deltaTime); //begins the flip that continues in the next flip
            flip = true;
        }
        if (flip == true) //Best way i could get the smooth rotation and flip to occur
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.identity, 360 * Time.deltaTime);
            if (transform.rotation == Quaternion.identity)
            {
                    fired = false;
                    flip = false;
                if (PumpAction == false && GrenadeLauncher == false && ammo != 2 || ammo == 0  ) 
                {
                    SG.saw();
                    ammo = 2;
                }
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("PumpAction"))
        {
            SG.pump();
            plsfx.PumpPickup(PAsound);
            PAsound = Random.Range(1, 4);
            collision.gameObject.SetActive(false);
            ammo = 6;
            PumpAction = true;
        }
        if (collision.transform.CompareTag("GrenadeLauncher"))
        {
            plsfx.GLpickup(GLsound);
            GLsound = Random.Range(1, 4);
            collision.gameObject.SetActive(false);
            ammo = 1;
            GrenadeLauncher = true;
        }
        if (collision.transform.CompareTag("BouncePad"))
        {
            rg2d.velocity += Vector2.up * BounceForce;
        }
        if (collision.transform.CompareTag("StickyPlatform"))
        {

            //This ill make it so the player will just freeze where is it giving the illusion of it sticking to the wall
            rg2d.velocity = Vector2.zero;
            rg2d.constraints = RigidbodyConstraints2D.FreezeRotation;
            rg2d.isKinematic = true;
            //This will then be set to false once the player fires

            //It also reloads the shotgun
            if (PumpAction == false && GrenadeLauncher == false && ammo != 2 || ammo == 0)
            {
                SG.saw();
                ammo = 2;
            }

        }
        if (collision.transform.CompareTag("Checkpoint"))
        {
            collision.gameObject.GetComponent<Checkpoint>().SetCheckpoint();
        }
    }

    public void Reload(int amount)
    {
        ammo += amount;
    }

    public bool checkFired()
    {
        return fired;
    }

    public float checkVelocityX()
    {
        return rg2d.velocity.x;
    }
}
