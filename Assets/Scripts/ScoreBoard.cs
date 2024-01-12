using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    // starts at 0 by default
    int score;
    int highScore;
    TMP_Text scoreText;

    [SerializeField]
    GameObject buttons;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        ResetScoreBoard();
    }

    public void ResetScoreBoard()
    {
        buttons.SetActive(false);
        score = 0;
        scoreText.text = $"Ola boi, your score: {score}";
        GetComponent<RectTransform>().transform.position = new Vector2(135, 14);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = $"Ola boi, your score: {score}";
    }

    public void Finish()
    {
        if (score > highScore)
        {
            highScore = score;
        }

        scoreText.text = $"Current score: {score} \n High score: {highScore}";
        GetComponent<RectTransform>().transform.position = new Vector2(490, 505);
        buttons.SetActive(true);
    }
}
