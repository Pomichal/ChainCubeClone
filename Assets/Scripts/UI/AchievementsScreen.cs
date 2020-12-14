using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AchievementsScreen : ScreenBase
{
    public TextMeshProUGUI text;

    public override void Show()
    {
        base.Show();

        ShowAchievementText(App.player.highestCubeScore);
    }

    public void ShowAchievementText(int score)
    {
        text.text = "New highest number " + score;
    }

}
