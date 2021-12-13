using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialTextController : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;
    public TMP_Text text;

    float timer;

    // Start is called before the first frame update
    void Start()
    {
        //text = GetComponent<TextMeshPro>().text;
        timer = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<player>().checkFired())
        {
            text.text = "Whoops! Looks like you got knocked back.\n" +
                "Hey! Maybe try shooting yourself into it?";
        }

        if (enemy.GetComponent<EnemyHealth>().alive == false)
        {
            text.text = "You did it! Now you can use this knowledge to your advantage!";
            timer -= Time.deltaTime;
        }

        if (timer <= 0f)
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
}
