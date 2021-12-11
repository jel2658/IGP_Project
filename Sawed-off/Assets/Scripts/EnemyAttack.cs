using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("Collided.");

        if (collision.collider.tag == "Player" && GetComponent<EnemyHealth>().alive)
        {
            collision.collider.GetComponent<PlayerHealth>().takeDamage(damage);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Player" && GetComponent<EnemyHealth>().alive)
        {
            collision.collider.GetComponent<PlayerHealth>().takeDamage(damage);
        }
    }
}
