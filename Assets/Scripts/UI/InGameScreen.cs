using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InGameScreen : ScreenBase
{

    public TextMeshProUGUI scoreText;

    public override void Show()
    {
        base.Show();
        App.player.onScoreChanged.AddListener(SetScoreText);
    }

    public override void Hide()
    {
        base.Hide();
        App.player.onScoreChanged.RemoveListener(SetScoreText);
    }

    public void ReturnToMenu()
    {
        App.screenManager.Show<MenuScreen>();
        Hide();
    }

    public void GameOver()
    {
        App.screenManager.Show<GameOverScreen>();
        Hide();

    }

    public void SetScoreText()
    {
        scoreText.text = "Score: " + App.player.GetScore();
    }

    public void IncreaseScore()     // just for testing purposes, remove in final game!!
    {
        App.player.ChangeScore(10);
    }
}
