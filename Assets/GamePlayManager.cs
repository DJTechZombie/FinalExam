using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlayManager : MonoBehaviour
{

    public Text speedText;
    public Text sizeText;
    public Text timeLimitText;

    public float timeRemaining;

    void Start()
    {
        speedText.text = GameManager.instance.speed;
        sizeText.text = GameManager.instance.size;
        timeRemaining = GameManager.instance.timeLimit;

        GameManager.instance.lives = LivesTracker.lives;
        GameManager.instance.score = ScoreKeeper.newScore;
    }

    
    void Update()
    {
        if(GameManager.instance.timeLimit != 0)
        {
            timeRemaining -= Time.deltaTime;
            timeLimitText.text = timeRemaining.ToString("F2");
        }
        else
        {
            timeLimitText.text = "\u221E";
        }
    }

    public void NextScene()
    {
        GameManager.instance.NextLevel();
    }
}
