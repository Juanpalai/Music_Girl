using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stageselec : MonoBehaviour
{

    public static int stage=1;
    // Start is called before the first frame update
    void Start()
    {
        stage = 1;
    }
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
