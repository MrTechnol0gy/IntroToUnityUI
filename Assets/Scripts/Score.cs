using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Threading;

public class Score : MonoBehaviour
{
    protected int score;
    private bool playable = false;
    private string startMessage = "Push Start To start!";
    [SerializeField] AudioSource scoreUp;
    [SerializeField] AudioSource ScoreDown;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI debugText;

    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        SetScoreText();   
        debugText.text = startMessage.ToString();            
    }

    // Update is called once per frame
    void Update()
    {
        ClampScore();
        SetScoreText();
    }
    void SetScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void IncreaseScore()
    {
        if (playable)
        {
            score += 5;
            scoreUp.Play();
            debugText.text = "You've gained 5 points!".ToString();
        }
    }

    public void DecreaseScore()
    {
        if (playable)
        {
            score -= 5;
            ScoreDown.Play();
            debugText.text = "You've lost 5 points!".ToString();
        }
    }

    public void StartGame()
    {
        if (playable == false)
        {
            playable = true;            
            debugText.text = "The game is now playable.".ToString();
        }
    }

    void ClampScore()
    {
        if (score < 0)
        {
            score = 0;            
            debugText.text = "Going below zero resets you to zero.".ToString();
        }
        else if (score > 999)
        {
            score = 999;            
            debugText.text = "Going above 999 resets you to 999.".ToString();
        }
    }

    public void QuitGame()
    {        
        debugText.text = "Application will now close.".ToString();
        Thread.Sleep(3000);
        Application.Quit();
    }
}
