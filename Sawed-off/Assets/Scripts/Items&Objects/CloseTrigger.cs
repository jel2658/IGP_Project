using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTrigger : MonoBehaviour
{
    public GameObject Door;
    BoxCollider2D box;

    private void Awake()
    {
        box = GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Player") == true)
        {
            Door.SetActive(true);
            GameObject.Destroy(this.gameObject);
        }
    }
}
