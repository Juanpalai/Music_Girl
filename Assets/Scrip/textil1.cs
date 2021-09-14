using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class textil1 : MonoBehaviour
{
    int opc = 1;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("Text2S").GetComponentInChildren<Text>().text = "Stage 1";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            opc++;
            if (opc == 3)
            {
                opc = 1;
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            opc--;
            if (opc == 0)
            {
                opc = 2;
            }
        }
        if (opc == 1)
        {
            GameObject.Find("Text2S").GetComponentInChildren<Text>().text = "Stage 1";
        }
        if (opc == 2)
        {
            GameObject.Find("Text2S").GetComponentInChildren<Text>().text = "Stage 2";
        }       
    }
}
