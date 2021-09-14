using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SlectStage : MonoBehaviour
{
    public AudioSource flahs;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = new Color32(255, 255, 225, 100); 

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            flahs.Play();
            GetComponent<Image>().color = new Color32(255, 255, 225, 100); ;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            flahs.Play();
            GetComponent<Image>().color = Color.white;
        }


    }
}