using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchGuns : MonoBehaviour
{
    public Sprite sawR;
    public Sprite sawL;

    public Sprite pumpR;
    public Sprite pumpL;

    public SpriteRenderer rhand;
    public SpriteRenderer lhand;
    public void pump()
    {
        rhand.sprite = pumpR;
        lhand.sprite = pumpL;
    }

    public void saw()
    {
        rhand.sprite = sawR;
        lhand.sprite = sawL;
    }
}
