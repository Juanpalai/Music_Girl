using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BGsatage : MonoBehaviour
{
    [SerializeField]
    private Sprite[] bg;

    int opc = 1;
    // Start is called before the first frame update
    void Start()
    {

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

            GameObject.Find("BG").GetComponentInChildren<Image>().sprite = bg[opc - 1];
        }
        if (opc == 2)
        {

            GameObject.Find("BG").GetComponentInChildren<Image>().sprite = bg[opc - 1];
        }       
    }
}
