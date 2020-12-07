using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesPool : MonoBehaviour
{

    public GameObject mergeParticles;

    public List<GameObject> spawnedParticles = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        App.pool = this;
    }

    public GameObject GetParticle()
    {
        GameObject p = null;
        foreach(GameObject o in spawnedParticles)
        {
            if(!o.activeSelf)
            {
                p = o;
                break;
            }
        }
        if(p == null)
        {
            p = Instantiate(mergeParticles);
            spawnedParticles.Add(p);
        }
        p.SetActive(true);
        return p;
    }
}
