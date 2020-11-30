using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    void Start()
    {
        App.gameManager = this;
        App.screenManager.Show<MenuScreen>();

        App.player = new PlayerModel();      // TODO: load player data
    }

    public void PrepareLevel()
    {
        Debug.Log("Preparing the level...");
    }
}
