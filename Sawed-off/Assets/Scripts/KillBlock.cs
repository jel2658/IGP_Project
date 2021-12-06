using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillBlock : MonoBehaviour
{
    GameObject[] Checkpoints;
    public Transform player;

    // Start is called before the first frame update
    private void Awake()
    {
        Checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.transform.CompareTag("Player"))
        {
            for(int i = 0; i < Checkpoints.Length; ++i)
            {
                if (Checkpoints[i].gameObject.GetComponent<Checkpoint>().active == true){
                    collision.transform.position = Checkpoints[i].GetComponent<Transform>().position;
                }
            }
        }
    }
}
