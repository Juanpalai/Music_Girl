using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class flechas : MonoBehaviour
{
    int opc = 1;
    public AudioSource flahs;

    // Start is called before the first frame update
    void Start()    {
        opc = 1;

    }

    // Update is called once per frame   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            flahs.Play();
            opc++;
            if (opc == 4)
            {
                opc = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            flahs.Play();
            opc--;
            if (opc == 0)
            {
                opc = 3;
            }
        }
        if (opc == 3)
        {
            transform.position = GameObject.Find("Button").transform.position;
            if (Input.GetKeyDown(KeyCode.B)|| Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("UI1");
            }
        }
        if (opc == 2)
        {
            transform.position = GameObject.Find("Button (1)").transform.position;
            if (Input.GetKeyDown(KeyCode.B)|| Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("UI3");
            }
        }
        if (opc == 1)
        {
            transform.position = GameObject.Find("Button (2)").transform.position;
            if (Input.GetKeyDown(KeyCode.B) || Input.GetKey(KeyCode.Return))
            {
                FindObjectOfType<Puse>().pause = false;
                FindObjectOfType<PlayerController>().pause = false;
                Time.timeScale = 1f;
            }
        }
    }    
}
