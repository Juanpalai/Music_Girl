using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class akibastar : MonoBehaviour
{
    
    private Animator anim;
    void Start()
    {
        
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Stageselec.stage == 1)
        {
            anim.SetBool("star", true);
        }

    }
}
