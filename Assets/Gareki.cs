using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gareki : MonoBehaviour
{
    private AudioSource Explosion;
    // Start is called before the first frame update
    void Start()
    {
        Explosion = GameObject.Find("Explosion").GetComponent<AudioSource>();
    }    
    
	void OnTriggerEnter2D(Collider2D collider)
	{		
		if (collider.tag == "Ballet2")
		{
			Destroy(collider.gameObject);			
			Explosion.Play();
            Destroy(gameObject); 

		}
		

	}
}
