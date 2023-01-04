using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LevelSelctor : MonoBehaviour
{
    public GameObject button;
    public Sprite starSprite;
    public int Stage;
    public Text StageText;

    [SerializeField] private bool unlocked;
    public Image unlockImage;
    public GameObject[] stars;


    void Start()
    {
        StageText.text = Stage.ToString();
    }

    void Update()
    {
        UpdateLevelImage();
        UpdateLevelStars();
    }

    public void OpenScene()
    {
        SceneManager.LoadScene("Stage " + Stage.ToString());
    }

    private void UpdateLevelImage()
    {

        if (!unlocked)
        {
            unlockImage.gameObject.SetActive(true);
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(false);
            }
        }
        else
        {
            unlockImage.gameObject.SetActive(false);
            for(int i = 0; i < stars.Length; i++)
            {
                stars[i].gameObject.SetActive(true);
            }

            for (int i = 0; i < PlayerPrefs.GetInt("Lv" + gameObject.name); i++)
            {
                stars[i].gameObject.GetComponent<Image>().sprite = starSprite;
            }
        }
    }

    private void UpdateLevelStars()
    {
        int previousLevelNum = int.Parse(gameObject.name) - 1;

        if (PlayerPrefs.GetInt("Lv" + previousLevelNum.ToString()) > 0)
        {
            unlocked = true;
        }

    }
    
}
