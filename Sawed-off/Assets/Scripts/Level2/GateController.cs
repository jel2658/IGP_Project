using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    public GameObject button;

    bool unlocked;
    Transform gateClosed;
    Transform gateOpen;

    // Start is called before the first frame update
    void Start()
    {
        //unlocked = button.GetComponent<ButtonController>().pressed;
        gateClosed = transform.Find("gateClosed");
        gateOpen = transform.Find("gateOpen");
        gateOpen.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (button.GetComponent<ButtonController>().pressed)
        {
            gateClosed.gameObject.SetActive(false);
            gateOpen.gameObject.SetActive(true);
            enabled = false;
        }
    }
}
