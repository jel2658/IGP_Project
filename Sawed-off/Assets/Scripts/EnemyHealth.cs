using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public bool alive;

    // Start is called before the first frame update
    void Start()
    {
        alive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!alive)
        {
            gameObject.GetComponent<EnemyWalk>().enabled = false;
        }
    }

    public void Shot()
    {
        alive = false;
        transform.Rotate(0f, 0f, 45f, Space.Self);
    }
}
