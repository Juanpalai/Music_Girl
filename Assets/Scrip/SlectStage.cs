using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class tutorial   : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().color = Color.white;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.B) || Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("UI3");
        }
    }
}
