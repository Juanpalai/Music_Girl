using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage2mussic : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip newTrack;
    private AudioManager theAM;
    void Start()
    {
        theAM = FindObjectOfType<AudioManager>();
    }

    void OnTriggerEnter2D(Collider2D other)
        {

            if (other.tag == "Player")
            {
               // Debug.Log("change");
                if (newTrack != null)
                {
                    theAM.ChangeBGM(newTrack);                    
                }

            }
        FindObjectOfType<tittle2>().enter = true;
        Stageselec.stage = 2;
    }
    
}
