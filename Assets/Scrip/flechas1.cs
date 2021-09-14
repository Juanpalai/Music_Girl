using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class flechas1 : MonoBehaviour
{
    int opc = 1;
    public AudioSource flahs;

    // Start is called before the first frame update
    void Start()    {

        Time.timeScale += 0.05f;
        
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
            transform.position = GameObject.Find("Button").transform.position;
            if (Input.GetKeyDown(KeyCode.B)|| Input.GetKey(KeyCode.Return))
            {
                GameObject.Find("Panel").GetComponent<Animator>().SetBool("Exit", true);
                StartCoroutine(Change());                
            }
        }
        if (opc == 2)
        {
            transform.position = GameObject.Find("Button (1)").transform.position;
            if (Input.GetKeyDown(KeyCode.B)|| Input.GetKey(KeyCode.Return))
            {
                GameObject.Find("Panel").GetComponent<Animator>().SetBool("Exit", true);
                StartCoroutine(Change1());               
            }
        }       
    }
    IEnumerator Change()
    {        
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("GameOka");
    }
    IEnumerator Change1()
    {
        yield return new WaitForSeconds(.5f);
        SceneManager.LoadScene("UI1");
    }
}
