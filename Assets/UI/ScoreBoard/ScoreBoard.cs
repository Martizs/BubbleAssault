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

    [SerializeField]
    float textStartXPercentage = 13;

    [SerializeField]
    float textStartYPercentage = 2.5f;

    [SerializeField]
    float textFinishXPercentage = 47;

    [SerializeField]
    float textFinishYPercentage = 88;

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

        GetComponent<RectTransform>().transform.position = new Vector2(
            Screen.width * textStartXPercentage / 100,
            Screen.height * textStartYPercentage / 100
        );
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
        GetComponent<RectTransform>().transform.position = new Vector2(
            Screen.width * textFinishXPercentage / 100,
            Screen.height * textFinishYPercentage / 100
        );
        buttons.SetActive(true);
    }
}
