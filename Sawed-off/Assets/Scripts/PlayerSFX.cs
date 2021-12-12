using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSFX : MonoBehaviour
{
    public void Gunshot(int numb)
    {

        switch (numb)
        {
            case 1:
                FindObjectOfType<AudioManager>().PlayGunshot("pow");
                break;
            case 2:
                FindObjectOfType<AudioManager>().PlayGunshot("pow2");
                break;
            case 3:
                FindObjectOfType<AudioManager>().PlayGunshot("blam");
                break;
            case 4:
                FindObjectOfType<AudioManager>().PlayGunshot("boom");
                break;
            case 5:
                FindObjectOfType<AudioManager>().PlayGunshot("koom");
                break;
        }
    }

    public void PumpPickup(int numb)
    {
        switch (numb)
        {
            case 1:
                FindObjectOfType<AudioManager>().PlayPumpAction("pumpaction");
                break;
            case 2:
                FindObjectOfType<AudioManager>().PlayPumpAction("pumpaction2");
                break;
            case 3:
                FindObjectOfType<AudioManager>().PlayPumpAction("chikchik");
                break;
            case 4:
                FindObjectOfType<AudioManager>().PlayPumpAction("Shorty");
                break;
        }
    }

    public void GLpickup(int numb)
    {

        switch (numb)
        {
            case 1:
                FindObjectOfType<AudioManager>().PlayGrenadeLauncher("glch");
                break;
            case 2:
                FindObjectOfType<AudioManager>().PlayGrenadeLauncher("glch2");
                break;
            case 3:
                FindObjectOfType<AudioManager>().PlayGrenadeLauncher("glboom");
                break;
            case 4:
                FindObjectOfType<AudioManager>().PlayGrenadeLauncher("thump");
                break;
            case 5:
                FindObjectOfType<AudioManager>().PlayGrenadeLauncher("kboom");
                break;
        }
    }

}
