using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Level_Selection : MonoBehaviour
{
    public Button[] lvlbuttons;
    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);

        for (int i = 0; i < lvlbuttons.Length; i++)
        {
            if ( i + 2 > levelAt)
            {
                lvlbuttons[i].interactable = false;

            }
        }
    }

   
}
