using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int startingHealth;
    public int currentHealth;
    bool isDead;

    public TMP_Text healthText;

    void Awake()
    {
        currentHealth = startingHealth;
    }

    // Start is called before the first frame update
    void Start()
    {
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
        healthText.text = "Health: " + currentHealth;
    }

    void Death()
    {
        GetComponent<player>().enabled = false;
        transform.Rotate(0f, 45f, 0f, Space.Self);
    }
}
