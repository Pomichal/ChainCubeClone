using System.Collections;
using System.Collections.Generic;
using Models;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject mergeParticles;
    public UnityEvent onCubeReleased = new UnityEvent();
    public List<GameObject> cubes = new List<GameObject>();

    public class CollisionEvent : UnityEvent<GameObject[]> {}
    public CollisionEvent onCollisonEvent = new CollisionEvent();
    void Start()
    {
        App.gameManager = this;
        App.screenManager.Show<MenuScreen>();

        App.player = new PlayerModel();      // TODO: load player data
        onCollisonEvent.AddListener(HandeCollision);
        onCubeReleased.AddListener(() =>
        {
            StartCoroutine("SpawnCube");
        });
    }

    public void PrepareLevel()
    {
        Debug.Log("Preparing the level...");
        StartCoroutine("SpawnCube");
    }

    void HandeCollision(GameObject[] collidedCubes)
    {
        if (collidedCubes[0].GetComponent<CubeBehaviour>().getModel().cubeValue ==
            collidedCubes[1].GetComponent<CubeBehaviour>().getModel().cubeValue)
        {
            Destroy(collidedCubes[0]);
            Destroy(collidedCubes[1]);

            Instantiate(mergeParticles, collidedCubes[0].transform.position, Quaternion.identity);

            App.player.ChangeScore(collidedCubes[1].GetComponent<CubeBehaviour>().getModel().cubeValue);

            //TODO erase gameObject also from the List
        }
    }

    IEnumerator SpawnCube()
    {
        yield return new WaitForSeconds(0.5f);
        CubeModel cubeModel = new CubeModel((int) Mathf.Pow(2, Random.Range(1, 7)));
        var spawnedCube = Instantiate(cubePrefab, new Vector3(0, 1, -5), Quaternion.identity);
        cubes.Add(spawnedCube);

        spawnedCube.GetComponent<CubeBehaviour>().setModel(cubeModel);
    }

    public void DestroyCubes()
    {
        if(cubes == null)
            return;
        foreach(GameObject cube in cubes)
        {
            Destroy(cube);
        }
    }
}
