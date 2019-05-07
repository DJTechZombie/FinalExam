using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuiController : MonoBehaviour
{
    public Slider sizeSlider;
    public Slider speedSlider;
    public Toggle optionsToggle;
    public Dropdown timeLimitDropdown;

    private Text sizeText;
    private Text speedText;

    public GameObject optionsPanel;

    private void Awake()
    {
        sizeText = sizeSlider.GetComponentInChildren<Text>();
        speedText = speedSlider.GetComponentInChildren<Text>();
    }
    public void DisplayOptions(bool _options)
    {
        optionsPanel.SetActive(_options);
    }

    public void SetTimeLimit()
    {
        switch(timeLimitDropdown.value)
        {
            case 0: GameManager.instance.timeLimit = 60f;
                break;
            case 1: GameManager.instance.timeLimit = 120f;
                break;
            case 3: GameManager.instance.timeLimit = 0f; //Unlimited Time
                break;
        }
    }

    public void SetSize()
    {
        switch(sizeSlider.value)
        {
            case 0: GameManager.instance.size = "1/4x";
                break;
            case 1: GameManager.instance.size = "1/2x";
                break;
            case 2: GameManager.instance.size = "1x";
                break;
            case 3: GameManager.instance.size = "1.25x";
                break;
            case 4: GameManager.instance.size = "1.5x";
                break;
        }
        sizeText.text = "Size : " + GameManager.instance.size;

    }

    public void SetSpeed()
    {
        switch(speedSlider.value)
        {
            case 0:
                GameManager.instance.speed = "1/4x";
                break;
            case 1:
                GameManager.instance.speed = "1/2x";
                break;
            case 2:
                GameManager.instance.speed = "1x";
                break;
            case 3:
                GameManager.instance.speed = "1.25x";
                break;
            case 4:
                GameManager.instance.speed = "1.5x";
                break;
        }
        speedText.text = "Speed : " + GameManager.instance.speed;
    }

    public void NextScene()
    {
        GameManager.instance.NextLevel();
    }
}
