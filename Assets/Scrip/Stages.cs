using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Stages : MonoBehaviour
{
    [SerializeField]
    private Font[] myfont;

    public AudioSource flahs;
    private int counter;
    int opc = 1;
    // Start is called before the first frame update
    void Start()
    {
         counter = 0;     
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            flahs.Play();
            opc++;
            if (opc == 3)
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
                opc = 2;
            }
        }
        if (opc == 1)
        {
            GameObject.Find("Button").GetComponentInChildren<Text>().text = "アキハバラ";
            GameObject.Find("Button").GetComponentInChildren<Text>().font = myfont[opc-1];            
            if (Input.GetKeyDown(KeyCode.B)|| Input.GetKey(KeyCode.Return))
            {
                Stageselec.stage = 1;
                SceneManager.LoadScene("GameOka");
               
            }
        }
        if (opc == 2)
        {
            GameObject.Find("Button").GetComponentInChildren<Text>().text = "チカテツ";
            GameObject.Find("Button").GetComponentInChildren<Text>().font = myfont[opc - 1];
            if (Input.GetKeyDown(KeyCode.B) || Input.GetKey(KeyCode.Return))
            {
                Stageselec.stage = 2;                
                SceneManager.LoadScene("GameOka");

            }
        }        
    }
}
