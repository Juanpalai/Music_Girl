using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject explosion;
    // Start is called before the first frame update
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Spike" && other.tag != "Ballet")
        {
            Instantiate(explosion, transform.position, transform.rotation);
            GameObject clone = GameObject.Find("ExpAnimator(Clone)");
            Destroy(clone, 1);
        }
    }
    }
