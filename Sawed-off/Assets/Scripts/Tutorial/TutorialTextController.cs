using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialTextController : MonoBehaviour
{
    public TMP_Text tutorialText;
    public GameObject enemy1;

    float timer;

    //bool enemy1Alive;

    // Start is called before the first frame update
    void Start()
    {
        timer = 5f;
        //enemy1Alive = enemy1.GetComponent<EnemyHealth>().alive;
    }

    // Update is called once per frame
    void Update()
    {
        if (!enemy1.GetComponent<EnemyHealth>().alive)
        {
            tutorialText.text = "Oops! Looks like you got shot backwards from the Recoil.\n" +
                "No worries! You're still alive. Hey!\n" +
                "Maybe you can use that to get around?";
            timer -= Time.deltaTime;
        }
        if (timer <= 0f)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
