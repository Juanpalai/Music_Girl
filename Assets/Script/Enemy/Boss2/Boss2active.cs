using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss2active : MonoBehaviour
{

    public GameObject Boss2;
    // Start is called before the first frame update
    void Start()
    {
        Boss2.SetActive(false);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Boss2.SetActive(true);

        }

    }
}
