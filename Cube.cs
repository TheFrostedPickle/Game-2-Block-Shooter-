using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{

    public GameObject deathParticles;

    public void Die()
    {
        GameObject particles = Instantiate(deathParticles, transform.position, deathParticles.transform.localRotation);

        Destroy(particles, 2f);
        Destroy(gameObject);
    }
}
