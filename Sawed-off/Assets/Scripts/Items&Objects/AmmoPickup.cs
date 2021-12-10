using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public int ammo;
    public float pickupRespawn;

    bool pickedUp;
    float timer;
    SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        pickedUp = false;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pickedUp)
        {
            spriteRenderer.enabled = false;
            timer += Time.deltaTime;
            if (timer >= pickupRespawn)
            {
                pickedUp = false;
                spriteRenderer.enabled = true;
                timer = 0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player" && !pickedUp)
        {
            other.GetComponent<player>().Reload(ammo);
            pickedUp = true;
        }
    }
}
