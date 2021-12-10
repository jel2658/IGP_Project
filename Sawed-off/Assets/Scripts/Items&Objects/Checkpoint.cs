using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{

    GameObject[] Checkpoints;
    public bool active;
    // Start is called before the first frame update
    private void Start()
    {
        Checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCheckpoint()
    {
        for(int i = 0; i < Checkpoints.Length; ++i)
        {
            Checkpoints[i].gameObject.GetComponent<Checkpoint>().active = false;
        }
        active = true;
    }
}
