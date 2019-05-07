using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text highScoreText;
    public Text statsText;

    private void Awake()
    {
        GameManager.instance.scoreManager.AddScore(GameManager.instance.playerName, GameManager.instance.score, GameManager.instance.lives);
    }

    void Start()
    {
        statsText.text = GameManager.instance.playerName + '\n' + "Score: " + GameManager.instance.score.ToString() + '\n' +
            "Lives : " + GameManager.instance.lives.ToString();

        highScoreText.text = GameManager.instance.scoreManager.DisplayScores();
    }

    public void QuitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
