using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button[] buttons;

    void Awake()
    {
        //PlayerPrefs.SetInt("levelAt", 1);
    }

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt");
        int Lv = PlayerPrefs.GetInt("Lv");

        Debug.Log("levelAt levelmanager : " + levelAt);
        Debug.Log("Lv : " + Lv);

        for (int i = 0; i < buttons.Length; i++)
        {

            if( levelAt == 0)
            {
                buttons[0].interactable = true;

                if (i + 1 > levelAt)
                {
                    buttons[i].interactable = false;
                }
            }
        }
    }
}
