    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
       // GameObject.FindGameObjectWithTag("Music").GetComponent<MusicClass>().PlayMusic();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.B)|| Input.GetKey(KeyCode.Return))
        {

            SceneManager.LoadScene("GameOka");
        }
    }
}
