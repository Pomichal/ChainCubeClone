﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : ScreenBase
{
    public void ReturnToMenu()
    {
        App.screenManager.Show<MenuScreen>();
        Hide();
    }
}
