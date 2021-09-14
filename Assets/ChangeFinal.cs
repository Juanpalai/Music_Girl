using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChangeFinal : MonoBehaviour
{

    public GameObject Image2;
    bool change;
    // Start is called before the first frame update
    void Start()
    {
        change = false;
        Image2.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Change());
        if(change == true)
        {
            if (Input.GetKeyDown(KeyCode.B) || Input.GetKey(KeyCode.Return))
            {
                SceneManager.LoadScene("UI1");
            }
        }
    }

    IEnumerator Change()
    {
        yield return new WaitForSeconds(3f);
        Image2.SetActive(true);
        change = true;
    }
}
