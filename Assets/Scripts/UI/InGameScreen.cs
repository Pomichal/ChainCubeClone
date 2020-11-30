using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameScreen : ScreenBase
{

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
}
