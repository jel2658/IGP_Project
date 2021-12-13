using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;
    float reloadTimer;

    // Start is called before the first frame update
    void Start()
    {
        reloadTimer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collided.");

        if (collision.collider.tag == "Player" && collision.collider.GetComponent<player>().checkVelocityX() < 1.0f && GetComponent<EnemyHealth>().alive)
        {
            collision.collider.GetComponent<PlayerHealth>().takeDamage(damage);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && collision.collider.GetComponent<player>().checkVelocityX() < 1.0f && GetComponent<EnemyHealth>().alive)
        {
            collision.collider.GetComponent<PlayerHealth>().takeDamage(damage);
        } else if (collision.collider.tag == "Player")
        {
            if (reloadTimer > 0)
            {
                reloadTimer -= Time.deltaTime;
            } else
            {
                collision.collider.GetComponent<player>().setAmmo(2);
                reloadTimer = 5f;
            }
        }
    }
}
