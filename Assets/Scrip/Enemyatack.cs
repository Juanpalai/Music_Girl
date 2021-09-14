using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyatack : MonoBehaviour
{
    public GameObject atack;

   // bool exist = false;

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(atack, transform.position + new Vector3(-4f * Time.deltaTime, 0, 0), transform.rotation);

    }

    // Update is called once per frame
    void Update()
    {
        atack.transform.Translate(-4f * Time.deltaTime, 0, 0);

    }
}
