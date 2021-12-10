using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlickPlatform : MonoBehaviour
{
    float drag = 0.2f;
    public float newdrag;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") == true)
        {
            collision.GetComponent<Rigidbody2D>().drag = newdrag;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.transform.CompareTag("Player") == true)
        {
            other.GetComponent<Rigidbody2D>().drag = drag;
        }
    }
}
