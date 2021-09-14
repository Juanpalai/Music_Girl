using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage3 : MonoBehaviour
{
    
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerController>().down = true;
            FindObjectOfType<PlayerController>().Damage();
            FindObjectOfType<PlayerController>().comeback3();
        }
    }
}
