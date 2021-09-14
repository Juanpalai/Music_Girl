using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SwitchMusicTrigger : MonoBehaviour
{
    public AudioClip newTrack;
    bool stoopcamera;
    private AudioManager theAM;

    public GameObject BosuHP;

    public GameObject Boss;

    // Start is called before the first frame update
    void Start()
    {
        theAM = FindObjectOfType<AudioManager>();
        stoopcamera = false;
        BosuHP.SetActive(false);
        Boss.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<PlayerController>().isGrounded && stoopcamera)        {
           
            FindObjectOfType<PlayerController>().cam = true;
            Destroy(gameObject);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {

            stoopcamera = true;
            if (newTrack !=null)
            {
                theAM.ChangeBGM(newTrack);

                BosuHP.SetActive(true);
                Boss.SetActive(true);                

            }
        
        }
    }
}
