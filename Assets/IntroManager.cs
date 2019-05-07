using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroManager : MonoBehaviour
{
    public InputField playerNameInput;
    public Text scoreText;

    private void Start()
    {
        scoreText.text = GameManager.instance.scoreManager.DisplayScores();
    }

    public void setPlayerName()
    {
        GameManager.instance.playerName = playerNameInput.text;
    }

    public void LoadNextScene()
    {
        if (GameManager.instance.playerName == "")
        {
            GameManager.instance.playerName = "Anonymous";
        }
        GameManager.instance.NextLevel();

    }
}
