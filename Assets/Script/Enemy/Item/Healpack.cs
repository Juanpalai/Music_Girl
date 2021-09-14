using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healpack : MonoBehaviour
{
	int hp;
    // Start is called before the first frame update
    void Start()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Player")
		{

            FindObjectOfType<PlayerController>().HP += 5;
            Color();
			Destroy(this.gameObject);
		}
		// ボス消滅処理

	}
    void Color()
    {
		hp = FindObjectOfType<PlayerController>().HP;
		if(hp>10)
		{
			FindObjectOfType<PlayerController>().HP = 10;
			hp = 10;
		}

		for(int i =0; i<=hp; i++)
		{
			switch (i)
			{
				case 10:
					GameObject.Find("Heart 10").GetComponent<Image>().color = GameObject.Find("Heart 1").GetComponent<Image>().color;
					break;
				case 9:
					GameObject.Find("Heart 9").GetComponent<Image>().color = GameObject.Find("Heart 1").GetComponent<Image>().color;
					break;
				case 8:
					GameObject.Find("Heart 8").GetComponent<Image>().color = GameObject.Find("Heart 1").GetComponent<Image>().color;
					break;
				case 7:
					GameObject.Find("Heart 7").GetComponent<Image>().color = GameObject.Find("Heart 1").GetComponent<Image>().color;
					break;
				case 6:
					GameObject.Find("Heart 6").GetComponent<Image>().color = GameObject.Find("Heart 1").GetComponent<Image>().color;
					break;
				case 5:
					GameObject.Find("Heart 5").GetComponent<Image>().color = GameObject.Find("Heart 1").GetComponent<Image>().color;
					break;
				case 4:
					GameObject.Find("Heart 4").GetComponent<Image>().color = GameObject.Find("Heart 1").GetComponent<Image>().color;
					break;
				case 3:
					GameObject.Find("Heart 3").GetComponent<Image>().color = GameObject.Find("Heart 1").GetComponent<Image>().color;
					break;
				case 2:
					GameObject.Find("Heart 2").GetComponent<Image>().color = GameObject.Find("Heart 1").GetComponent<Image>().color;
					break;
				case 1:
					GameObject.Find("Heart 1").GetComponent<Image>().color = GameObject.Find("Heart 1").GetComponent<Image>().color;
					break;

			}
		}
		
	}
}
