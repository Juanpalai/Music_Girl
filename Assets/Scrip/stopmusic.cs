using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopmusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().StopMusic();
    }    
}
