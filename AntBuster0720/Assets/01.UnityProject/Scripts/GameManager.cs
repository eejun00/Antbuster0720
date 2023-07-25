using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public bool isGameover = false;
    public TMP_Text scoreText;
    public TMP_Text levelText;
    public TMP_Text moneyText;
    public GameObject gameoverUi;

    private int score = 0;
    private int waveLevel = 1;
    public int money = 100;
    public int life = 8;
    public int mushCount = 8;

    public GameObject clickedTower;

    private void Awake()
    {
        if (instance.IsValid() == false)
        {
            instance = this;
        }
        else
        {
            GFunc.LogWarning("씬에 두 개 이상의 게임 매니저가 존재합니다!");
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        GetMoney(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(life == 0)
        {
            EndGame();
        }
        if (isGameover == true && Input.GetMouseButton(0))
        {
            GFunc.LoadScene(GFunc.GetActiveSceneName());
        }
    }

    public void AddScore(int newScore)
    {
        if (isGameover == false)
        {
            score += newScore;
            scoreText.text = string.Format("SCORE \n{0}", score);
        }
    }

    public void PlusWaveLevel()
    {
        if(!isGameover)
        {
            waveLevel += 1;
            levelText.text = string.Format("Next Lv.{0}", waveLevel);
        }
    }

    public void GetMoney(int money_)
    {
        if (isGameover == false)
        {
            if (money + money_ < 0)
            { /*Do nothing*/}
            else
            {
                money += money_;
                moneyText.text = string.Format("MONEY \n{0}", money);
            }
        }
    }

    public void EndGame()
    {
        isGameover = true;
        gameoverUi.SetActive(true);
    }
}