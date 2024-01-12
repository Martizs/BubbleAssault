using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    // starts at 0 by default
    int score;
    TMP_Text scoreText;

    private void Start()
    {
        scoreText = GetComponent<TMP_Text>();
        scoreText.text = $"Ola boi, your score budiet: {score}";
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = $"Ola boi, your score budiet: {score}";
    }
}
