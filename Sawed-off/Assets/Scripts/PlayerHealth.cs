using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    bool isDead;

    bool tookDamage;        // Tracks whether the player has been damaged.
    float damageCountdown;  // The amount of seconds of invincibility the Player has before being damaged again.

    public TMP_Text healthText;

    Rigidbody2D rb;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        damageCountdown = 0f;
        isDead = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }

        if (damageCountdown > 0.0f)
        {
            damageCountdown -= Time.deltaTime;
        } else
        {
            tookDamage = false;
            damageCountdown = 0f;
        }

        healthText.text = "Health: " + currentHealth;
    }

    void Death()
    {
        GetComponent<player>().enabled = false;
        transform.Rotate(0f, 0f, 45f, Space.Self);
        isDead = true;
    }

    public void takeDamage(int amount)
    {
        if (tookDamage)
        {
            return;
        } else
        {
            currentHealth -= amount;
            tookDamage = true;
            damageCountdown = 3f;
        }
    }

    void OnColliderEnter2D(Collider2D other)
    {
        float force = 3;

        if (other.tag == "Enemy") // Code to push the player away from the enemy.
        {
            Vector2 dir = transform.position - other.transform.position;

            dir = -dir.normalized;

            rb.AddForce(dir * force * Time.deltaTime);
        }
    }
}
