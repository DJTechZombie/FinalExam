using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public ScoreManager scoreManager;

    public string speed = "1";
    public string size = "1";
    public float timeLimit = 60f;
    public string playerName;

    public int score;
    public int lives;

    void Awake()
    {

        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        scoreManager.CheckForScores();
    }

    public void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Current Scene: " + currentScene);
        SceneManager.LoadScene(currentScene + 1);
    }
}
