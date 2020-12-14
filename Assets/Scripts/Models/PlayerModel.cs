using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;

public class PlayerModel
{

    public UnityEvent onScoreChanged = new UnityEvent();

    private int score;
    public int highestCubeScore;
    // TODO: add other properties

    public PlayerModel()
    {
        score = 0;
        highestCubeScore = 16;
    }

    public int GetScore()
    {
        return score;
    }

    public void ChangeScore(int change = 1)
    {
        score += change;
        onScoreChanged.Invoke();
    }
}
