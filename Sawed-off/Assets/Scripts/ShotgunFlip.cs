using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunFlip : MonoBehaviour
{
    public GameObject Right;
    public GameObject Left;
    public Transform pivot;

    // Update is called once per frame
    void Update()
    {
        if(pivot.eulerAngles.z >= 180.01f && pivot.eulerAngles.z <= 359.9f)
        {
            //Debug.Log("Facing right");
            //The left shotgun turns off and right turns on
            Right.SetActive(true);
            Left.SetActive(false);
            //This solution is awful but it works
        }
        if (pivot.eulerAngles.z >= .01f && pivot.eulerAngles.z <= 179.9)
        {
            //Debug.Log("facing left");
            //The left shotgun turns off and right turns on
            Right.SetActive(false);
            Left.SetActive(true);
            //This solution is awful but it works
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Debug.Log(pivot.eulerAngles.z);
        }
    }
}
