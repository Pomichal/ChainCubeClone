using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Models;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{


    public float gameOverZone;

    public GameObject cubePrefab;
    public GameObject mergeParticles;

    public GameObject dragableCube;
    public List<GameObject> cubes = new List<GameObject>();

    public class ReleaseEvent : UnityEvent<GameObject> {};
    public ReleaseEvent onReleaseEvent = new ReleaseEvent();

    public class CollisionEvent : UnityEvent<GameObject[]> {}
    public CollisionEvent onCollisonEvent = new CollisionEvent();
    void Start()
    {
        App.gameManager = this;
        App.screenManager.Show<MenuScreen>();

        App.player = new PlayerModel();      // TODO: load player data
        onCollisonEvent.AddListener(HandeCollision);
        onReleaseEvent.AddListener((releasedCubeObject) =>
        {
            dragableCube = null;
            cubes.Add(releasedCubeObject);
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
        if (collidedCubes[0].GetComponent<CubeBehaviour>().GetModel().cubeValue ==
            collidedCubes[1].GetComponent<CubeBehaviour>().GetModel().cubeValue)
        {
            if (cubes.Contains(collidedCubes[0]) && cubes.Contains(collidedCubes[1]))
            {
                cubes.Remove(collidedCubes[0]);
                cubes.Remove(collidedCubes[1]);

                int newValue = collidedCubes[0].GetComponent<CubeBehaviour>().GetModel().cubeValue * 2;
                Vector3 spawnPos = collidedCubes[0].transform.position;

                Destroy(collidedCubes[0]);
                Destroy(collidedCubes[1]);

                var particles = App.pool.GetParticle();
                particles.transform.position = collidedCubes[0].transform.position;

                App.player.ChangeScore(collidedCubes[1].GetComponent<CubeBehaviour>().GetModel().cubeValue);

                //TODO erase gameObject also from the List

                CubeModel newCube = new CubeModel(newValue);

                if(newValue >= App.player.highestCubeScore)
                {
                    App.screenManager.Show<AchievementsScreen>();
                    App.player.highestCubeScore *= 2;
                }
                var spawnedCube = Instantiate(cubePrefab, spawnPos, Quaternion.identity);
                var cubeBehaviourComponent = spawnedCube.GetComponent<CubeBehaviour>();

                cubeBehaviourComponent.SetModel(newCube);

                var sameCube = cubes.DefaultIfEmpty(null).FirstOrDefault(x => x.GetComponent<CubeBehaviour>().GetModel().cubeValue == newValue);

                cubeBehaviourComponent.Jump(sameCube);
                cubes.Add(spawnedCube);
            }
        }
    }

    IEnumerator SpawnCube()
    {
        yield return new WaitForSeconds(0.5f);
        CubeModel cubeModel = new CubeModel((int) Mathf.Pow(2, Random.Range(1, 7)));
        dragableCube = Instantiate(cubePrefab, new Vector3(0, 1, -5), Quaternion.identity);
        var cubeBehaviourComponent = dragableCube.GetComponent<CubeBehaviour>();
        cubeBehaviourComponent.SetModel(cubeModel);

        foreach(GameObject cube in cubes)
        {
            if(cube.transform.position.z < gameOverZone)
            {
                App.screenManager.Show<GameOverScreen>();
                App.screenManager.Hide<InGameScreen>();
                DestroyCubes();
            }
        }
    }

    public void DestroyCubes()
    {
        if(dragableCube != null)
            Destroy(dragableCube);
        if(cubes == null)
            return;
        foreach(GameObject cube in cubes)
        {
            Destroy(cube);
        }
        cubes = new List<GameObject>();
    }
}
