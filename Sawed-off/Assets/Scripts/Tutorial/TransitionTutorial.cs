﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionTutorial : MonoBehaviour
{
    //public Button btn;

    public void NextScene()
    {
        SceneManager.LoadScene("TutorialScene");
    }

    // Start is called before the first frame update
    void Start()
    {
        //btn = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}