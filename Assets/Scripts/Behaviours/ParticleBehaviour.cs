using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleBehaviour : MonoBehaviour
{
    private float timer;

    void OnEnable()
    {
        timer = GetComponent<ParticleSystem>().main.duration;
        StartCoroutine(DestroyParticle());
    }

    IEnumerator DestroyParticle()
    {
        yield return new WaitForSeconds(timer);
        gameObject.SetActive(false);
    }
}
