using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRange : MonoBehaviour
{
    public GameObject boundary;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x > boundary.transform.position.x && player.transform.position.x < transform.position.x)
        {
            GetComponent<EnemyWalk>().enabled = true;
            enabled = false;
        }
    }
}
