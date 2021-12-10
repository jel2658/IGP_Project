using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemRespawn : MonoBehaviour
{
    public GameObject pickup;
    float timerStart = 10.0f;
    public float timer;
    // Start is called before the first frame update
    void Awake()
    {
        timer = timerStart;
        pickup = transform.GetChild(0).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        //These will check if the pickup item has been picked up

        if(pickup.activeInHierarchy == false) //if the item was picked up then the timer will count down
        {
            timer -= Time.deltaTime;
        }
        if(timer <= 0) //when the timer is done it will then reactivate the pickup
        {
            pickup.SetActive(true);
        }
        if(pickup.activeInHierarchy == true) //resets the timer once active
        {
            timer = timerStart;
        }
    }
}
