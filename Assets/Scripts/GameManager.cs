using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public UnityEvent onCubeReleased = new UnityEvent();
    void Start()
    {
        App.gameManager = this;
        App.screenManager.Show<MenuScreen>();

        App.player = new PlayerModel();      // TODO: load player data
        onCubeReleased.AddListener(() =>
        {
            StartCoroutine("SpawnCube");
        });
    }

    public void PrepareLevel()
    {
        Debug.Log("Preparing the level...");
    }


    IEnumerator SpawnCube()
    {
        yield return new WaitForSeconds(0.5f);
        Instantiate(cubePrefab, new Vector3(0, 1, -5), Quaternion.identity);
    }
}
