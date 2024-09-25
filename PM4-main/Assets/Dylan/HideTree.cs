using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideTree : MonoBehaviour
{
    public static HideTree hideTree;

    public GameObject Panel;

    

    private void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy") ==  null)
        {
            Panel.SetActive(true);
        }
     
    }



}
