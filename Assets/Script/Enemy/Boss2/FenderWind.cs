using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenderWind : MonoBehaviour
{

	public float windSpeed;
	[SerializeField] 
	private int destroy = 2;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, destroy);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Rotate( new Vector3( 0, 0, 1 ) , windSpeed );
    }

	void OnTriggerEnter2D(Collider2D collider)
	{ 
		
		if( collider.gameObject.tag == "Ballet" )
		{
		
			Destroy( collider.gameObject );
		}
		if (collider.gameObject.tag == "Ballet2")
		{

			Destroy(collider.gameObject);
		}
	}
}
