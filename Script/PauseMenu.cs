using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    [SerializeField] private GameObject MenuSet;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Cancel") && (!GameManager.gameEnd))
        {
            Debug.Log("esc");
            if (!GameManager.isPause) 
            {
                CallMenu(); 
                Debug.Log("CallMenu");
            }
            else
            {
                CloseMenu();
                Debug.Log("CloseMenu");
            }
        }
    }

    private void CallMenu()
    {
        GameManager.isPause = true;
        MenuSet.SetActive(true);
    }

    private void CloseMenu()
    {
        GameManager.isPause = false;
        MenuSet.SetActive(false);

    }

    public void Continue()
    {
        CloseMenu();
        Debug.Log("CloseMenu");
    }

    public void RestartStage()
    {
        GameManager.instance.RestartStage();
    }

    public void ExitMenu()
    {
        GameManager.instance.ExitMenu();
    }
}
