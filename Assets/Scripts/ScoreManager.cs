using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class ScoreManager : MonoBehaviour
{
    public class Scores
    {
        public string playerName;
        public int finalScore;
        public int finalLives;
        public Scores(string _init, int _score, int _lives)
        {
            playerName = _init;
            finalScore = _score;
            finalLives = _lives;
        }
    }
    private string dataPath = "Assets";
    [SerializeField] public List<Scores> HighScores = new List<Scores>();


    public void CheckForScores()
    {
        if (!File.Exists(dataPath + "/scores.txt"))
        {
            InitializeScores();
            Debug.Log(dataPath + "/scores.txt created");
        }
        LoadScores();
    }

    public void InitializeScores()
    {
        List<Scores> _scores = new List<Scores>();
        _scores.Add(new Scores("Steve", 1942, 10));
        _scores.Add(new Scores("Tony", 316, 5));
        _scores.Add(new Scores("Natasha", 50, 0));
        _scores.Add(new Scores("Thor", 35, 8));
        _scores.Add(new Scores("Bruce", 30, 6));
        _scores.Add(new Scores("Clint", 11, 1));

        StreamWriter sw = new StreamWriter(dataPath + "/Scores.txt");

        for (int i = 0; i < _scores.Count; i++)
        {
            sw.WriteLine(String.Join(",", _scores[i].playerName.ToString(), _scores[i].finalScore.ToString(), _scores[i].finalLives.ToString()));
        }

        sw.Close();
    }


    public void SaveScores()
    {
        Debug.Log("Saving Scores");
        List<Scores> _scores = new List<Scores>();
        _scores = HighScores;

        StreamWriter sw = new StreamWriter(dataPath + "/Scores.txt");  //StreamWriter Save

        for (int i = 0; i < _scores.Count; i++)
        {
            sw.WriteLine(String.Join(",", _scores[i].playerName.ToString(), _scores[i].finalScore.ToString(), _scores[i].finalLives.ToString()));
        }

        sw.Close();

    }

    public void LoadScores()
    {
        Debug.Log("Loading Scores");
        if (File.Exists(dataPath + "/scores.txt"))
        {
            FileStream file = File.Open(dataPath + "/scores.txt", FileMode.Open);
            StreamReader sr = new StreamReader(file);
            List<Scores> _scores = new List<Scores>();
            while (!sr.EndOfStream)
            {
                string inputString = sr.ReadLine();
                string[] elements = inputString.Split(',');
                string inName = elements[0];
                int inScore = Convert.ToInt32(elements[1]);
                int inLives = int.Parse(elements[2]);
                Scores currentScore = new Scores(inName, inScore, inLives);
                _scores.Add(currentScore);
            }
            sr.Close();
            file.Close();

            HighScores = _scores;
        }
    }
    public void AddScore(string _init, int _score, int _lives)
    {
        Scores score = new Scores(_init, _score, _lives);
        HighScores.Add(score);
        sortScores();
    }

    public static int SortByScore(Scores p1, Scores p2)
    {
        return p1.finalScore.CompareTo(p2.finalScore);
    }
    public void sortScores()
    {
        HighScores.Sort(delegate (Scores x, Scores y)
        {
            return x.finalScore.CompareTo(y.finalScore);
        });
        HighScores.Reverse();
        SaveScores();
    }
    public string DisplayScores()
    {
        string allScores = string.Format("{0,-4}{1,-15}{2,10}{3,10}\n", "", "Name", "Score", "Lives");
        for (int i = 0; i < 5; i++)
        {
            allScores += string.Format("{0,-4}{1,-15}{2,10}{3,10}", i + 1 + ")", HighScores[i].playerName, HighScores[i].finalScore, HighScores[i].finalLives.ToString()) + '\n';
        }
        return allScores;
    }
}
