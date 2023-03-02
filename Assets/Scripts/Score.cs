using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    protected int score;
    private bool playable = false;
    [SerializeField] AudioSource scoreUp;
    [SerializeField] AudioSource ScoreDown;

    public TextMeshProUGUI scoreText;

    
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        SetScoreText();               
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
        }
    }

    public void DecreaseScore()
    {
        if (playable)
        {
            score -= 5;
            ScoreDown.Play();
        }
    }

    public void StartGame()
    {
        if (playable == false)
        {
            playable = true;
            Debug.Log("The game is now playable.");
        }
    }

    void ClampScore()
    {
        if (score < 0)
        {
            score = 0;
            Debug.Log("Going below zero resets you to zero.");
        }
        else if (score > 999)
        {
            score = 999;
            Debug.Log("Going above 999 resets you to 999.");
        }
    }

    public void QuitGame()
    {
        Debug.Log("Application will now close.");
        Application.Quit();
    }
}
