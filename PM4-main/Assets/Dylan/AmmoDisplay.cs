using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Shooting;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class AmmoDisplay : MonoBehaviour
{
    public TMP_Text ammoDisplay;
    public KeyCode Reload;

    // Update is called once per frame
    void Update()
    {
        ammoDisplay.text = shoot.maxAmmo.ToString();

        if (shoot.maxAmmo <= 0)
        {
            ammoDisplay.text = "EMPTY!";
        }

        if (Input.GetKey(Reload))
        {
            StartCoroutine(Reloading());
        }
    }
    public IEnumerator Reloading()
    {
        yield return new WaitForSeconds(0.5f);
        shoot.maxAmmo = shoot.totalMaxAmmo;
        ammoDisplay.text = "Reloading!";
    }
}
