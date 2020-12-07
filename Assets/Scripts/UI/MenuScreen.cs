using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreen : ScreenBase
{

    public override void Show()
    {
        base.Show();
        App.gameManager.DestroyCubes();
    }

    public void StartGame()
    {
        App.screenManager.Show<InGameScreen>();
        App.gameManager.PrepareLevel();
        Hide();
    }
}
