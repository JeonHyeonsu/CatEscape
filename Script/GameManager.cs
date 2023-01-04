using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public PlayerMove player;
    public GameObject[] stars;
    public Sprite starSprite;
    public int StageIndex;
    public float cleartime = 0;
    public int _starsNum = 0;
    public int coinGetNum = 0;

    private int currentStarNum = 0;

    public Text[] conditionText;
    public GameObject[] doors;
    public GameObject[] dooropens;

    public GameObject menuSet;
    public GameObject ClearMenuSet;
    public GameObject[] item;
    public static bool isPause = false;
    public static bool gameEnd = false;
    public Text timetext;
    public Text clearText;
    float time = 0.0f;


    public List<bool> clear = new List<bool>();
    public List<bool> conditions = new List<bool>();
    public List<int> clearTimes = new List<int>();

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Debug.LogWarning("씬에 두 개 이상의 게임 매니저가 존재");
            Destroy(gameObject);
        }
    }

    void Start()
    {
        gameEnd = false;
        isPause = false;
        _starsNum = 0;
        cleartime = 0;
    }

    public void NextStage()
    {
        SceneManager.LoadScene("Stage " + (StageIndex + 1));
    }

    public void RestartStage()
    {
        SceneManager.LoadScene("Stage " + (StageIndex));
    }

    public void TextColor()
    {
        if (clear[StageIndex - 1] == true)
        {
            conditionText[0].color = Color.green;
        }

        if (gameEnd == true && clearTimes[StageIndex - 1] > cleartime)
        {
            conditionText[1].color = Color.green;
        }

        if (conditions[StageIndex - 1] == true)
        {
            conditionText[2].color = Color.green;
        }

    }

    public void EndStage()
    {
        ClearMenuSet.SetActive(true);
        gameEnd = true;
        isPause = true;
        cleartime = time;

        Debug.Log("gameEndEndStage : " + gameEnd);

        clear.Insert(StageIndex - 1, true);

        if(clear[StageIndex - 1] == true)
        {
            _starsNum += 1;
            Debug.Log("clear _starsNum+1");
        }

        if(clearTimes[StageIndex - 1] > cleartime)
        {
            _starsNum += 1;
            Debug.Log("clearTimes _starsNum+1");
        }

        if ((StageIndex + 1) > PlayerPrefs.GetInt("levelAt"))
        {
            PlayerPrefs.SetInt("levelAt", (StageIndex + 1));
            int levelAt = PlayerPrefs.GetInt("levelAt");
            Debug.Log("levelAt gamemanager : " + levelAt);
        }

        clearText.text = "ClearTime: " + time.ToString("N2");

        StarScores();

    }

    public void StarScores()
    {
        Debug.Log("_starsNum : " + _starsNum);
        currentStarNum = _starsNum;
        if(currentStarNum > PlayerPrefs.GetInt("Lv" + StageIndex))
        {
            PlayerPrefs.SetInt("Lv" + StageIndex, _starsNum);
        }

        for (int i = 0; i < _starsNum; i++)
        {
            stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
        }
    }

    public void StarConditions()
    {

    }

    public void CoinGain()
    {
        coinGetNum += 1;
        Debug.Log("coinGetNum : " + coinGetNum);
        Debug.Log("itemLength : " + item.Length);
        if (coinGetNum == item.Length)
        {
            conditions.Insert(StageIndex - 1, true);
            _starsNum += 1;
            Debug.Log("conditions _starsNum+1");
        }
    }

    public void ItemGain()
    {
       conditions.Insert(StageIndex - 1, true);
       _starsNum += 1;
       Debug.Log("conditions _starsNum+1");
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene("LevelScenes");
    }

    public void DoorOpen()
    {
        Debug.Log("dooropen");
        //if (stageIndex <= doors.Length)
        //{
        doors[0].SetActive(false);
        dooropens[0].SetActive(true);
        conditions.Insert(StageIndex - 1, true);
        _starsNum += 1;
        Debug.Log("conditions _starsNum+1");
        //}
    }

    public void DoorClose()
    {
        Debug.Log("doorclose");

        doors[0].SetActive(true);
        dooropens[0].SetActive(false);

    }

    void Update()
    {

        TextColor();

        if (!isPause)
        {
            time += Time.deltaTime;
            timetext.text = "Time : " + time.ToString("N2");
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            PlayerPrefs.DeleteAll();
            Debug.Log("데이터 삭제");
        }

        if(item.Length != 0)
        {
            conditionText[2].text = "코인을 획득하세요  " + coinGetNum + "/" + item.Length;
        }
    }
}
