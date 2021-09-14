using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stopbg : MonoBehaviour
{   
    void Start()
    {
        GameObject.FindGameObjectWithTag("MusicBG").GetComponent<MusicClass>().StopMusic();
    }
}

