using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tittle2 : MonoBehaviour
{
    public bool enter;
    private Animator anim;
    void Start()
    {
        enter = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enter)
        {
            anim.SetBool("stage2", true);
        }

    }
}
