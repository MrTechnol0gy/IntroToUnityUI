using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    private int score;

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
        scoreText.text = "Score: " + score.ToString();
    }

    public void IncreaseScore()
    {
        score += 5;
    }

    public void DecreaseScore()
    {
        score -= 5;
    }

    void ClampScore()
    {
        if (score < 0)
        {
            score = 0;
        }
        else if (score > 999)
        {
            score = 999;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Application will now close.");
        Application.Quit();
    }
}
