using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameStart()
    {
        SceneManager.LoadScene("LevelScenes");
    }

    public void gameSetting()
    {
        SceneManager.LoadScene("");
    }

    public void gameExit()
    {
        Application.Quit();
    }
}
