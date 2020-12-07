using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    private float timer;

    void Start()
    {
        timer = GetComponent<ParticleSystem>().main.duration;
        Destroy(gameObject, timer);
    }
}
