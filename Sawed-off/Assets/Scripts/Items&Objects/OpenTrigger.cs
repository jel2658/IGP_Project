using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTrigger : MonoBehaviour
{
    public GameObject Door;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Player") == true)
        {
            Door.SetActive(false);
            GameObject.Destroy(this.gameObject);
        }
    }
}
