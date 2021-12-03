using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWalk : MonoBehaviour
{

    Animator anim;
    public GameObject player;
    public float speed;
    private Transform target;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        target = player.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x < transform.position.x)
        {
            anim.SetBool("WalkingLeft", true);
        } else if (player.transform.position.x > transform.position.x)
        {
            anim.SetBool("WalkingLeft", false);
        }

        transform.position = Vector2.MoveTowards(transform.position, new Vector2(player.transform.position.x, transform.position.y), speed * Time.deltaTime);
        
    }
}
