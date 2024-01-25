using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButonUI : MonoBehaviour
{
    ScoreBoard scoreBoard;

    private void Start()
    {
        scoreBoard = FindObjectOfType<ScoreBoard>();
    }

    public void TryAgainButton()
    {
        scoreBoard.ResetScoreBoard();
        SceneManager.LoadScene(0);
    }

    public void EndGameButton()
    {
        Application.Quit();
    }
}
