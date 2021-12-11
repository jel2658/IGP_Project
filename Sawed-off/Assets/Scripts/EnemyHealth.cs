using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public bool alive;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Shot()
    {
        alive = false;
        transform.Rotate(0f, 0f, 90f, Space.Self);
        gameObject.GetComponent<EnemyWalk>().enabled = false;
        anim.SetTrigger("Death");
        gameObject.GetComponent<EnemyAttack>().enabled = false;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && other.gameObject.GetComponent<player>().checkFired() && alive)
        {
            float velocityX = other.gameObject.GetComponent<player>().checkVelocityX();
            if (velocityX > 1.0f)
            {
                Shot();
            }
        }
    }
}
