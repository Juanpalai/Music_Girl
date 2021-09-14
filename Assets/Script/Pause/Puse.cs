using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puse : MonoBehaviour
{
    public bool pause;
    public GameObject screenpause;
    // Start is called before the first frame update
    void Start()
    {
        screenpause.SetActive(pause);
    }

    // Update is called once per frame
    void Update()
    {
        screenpause.SetActive(pause);        
    }
}
