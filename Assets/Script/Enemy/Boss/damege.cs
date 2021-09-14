using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damege : MonoBehaviour
{
   
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<PlayerController>().Damage();
            Destroy(gameObject);
        }
    }
}
