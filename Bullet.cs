using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float destroyTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, destroyTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        Cube cube = collision.transform.GetComponent<Cube>();

        if (cube != null)
        {
            cube.Die();
        }
    }
}
