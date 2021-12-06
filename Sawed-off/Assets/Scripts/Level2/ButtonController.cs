using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public GameObject button;
    public GameObject buttonPressed;

    public bool pressed;

    void Awake()
    {
        //button = Transform.Find("button");
        //buttonPressed = Transform.Find("button_pressed");
    }

    // Start is called before the first frame update
    void Start()
    {
        pressed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            buttonPressed.SetActive(true);
            button.SetActive(false);
            pressed = true;
        }
    }
}
