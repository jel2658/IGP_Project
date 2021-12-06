using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakAway : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("BreakAway"))
        {
            other.enabled = false;
        }
    }
}
