using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageClearMenu : MonoBehaviour
{

    [SerializeField] private GameObject clearMenuSet;

    void Start()
    {
        //nextSceneLoad = SceneManager.GetActiveScene().buildIndex + 1;
        //nextSceneLoad = GameManager.instance.StageIndex + 1;
    }

    //public void StageClear()
    //{
    //    Debug.Log("StageClear");
    //    MenuSet.SetActive(true);

    //    GameManager.instance.EndStage();

    //}

    //public void NextStage()
    //{
    //    Debug.Log(GameManager.instance.Stage + 1);
    //    SceneManager.LoadScene("Stage " + (GameManager.instance.Stage + 1));
    //}

    //public void NextStage()
    //{
    //    Debug.Log(GameManager.instance.Stage + 1);
    //    Debug.Log(PlayerPrefs.GetInt("levelAt"));
    //    SceneManager.LoadScene("Stage " + (GameManager.instance.Stage + 1));

    //    if((GameManager.instance.Stage + 1) > PlayerPrefs.GetInt("levelAt"))
    //    {
    //        Debug.Log("다음씬 열림");
    //        PlayerPrefs.SetInt("levelAt", (GameManager.instance.Stage + 1));
    //    }
    //}

    //public void NextStage()
    //{
    //    Debug.Log("Stage : " + (GameManager.instance.Stage + 1));
    //    Debug.Log("nextSceneLoad : " + nextSceneLoad);
    //    Debug.Log("ClearlevelAt : " + PlayerPrefs.GetInt("levelAt"));
    //    SceneManager.LoadScene("Stage " + nextSceneLoad);

    //    if (nextSceneLoad > PlayerPrefs.GetInt("levelAt"))
    //    {
    //        Debug.Log("다음씬 열림");
    //        PlayerPrefs.SetInt("levelAt", nextSceneLoad);
    //    }
    //}

    public void NextStage()
    {
        GameManager.instance.NextStage();
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
