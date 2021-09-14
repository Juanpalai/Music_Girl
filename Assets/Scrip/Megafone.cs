using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Megafone : MonoBehaviour
{
    public Sprite blue;
    public Sprite red;
    int op = 1;
    public bool redmegafone;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Image>().sprite = blue;        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && redmegafone)
        {
            if (op==1)
            {
                op = 2;
                return;
            }
            if (op==2)
            {
                op=1;
                return;
            }
        }
        if (op == 1)
        {
            GetComponent<Image>().sprite = blue;
        }
        if (op==2)
        {
            GetComponent<Image>().sprite = red;
        }
       
    }
}
