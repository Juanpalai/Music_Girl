using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{

	// 変数宣言
	[SerializeField] private float speed = 3.0f; // スピード
	[SerializeField] private int destroy = 5;	
	private GameObject player;
	private Vector2 Temp;

	public GameObject exposion;

	// 起動時に１回だけ呼び出されるメソッド
	void Start()
	{
		
		player = GameObject.FindWithTag("Player");
		Vector2 temp = transform.localScale;
		temp.x = player.transform.localScale.x*5;
		Temp = temp;
		transform.localScale = temp;		
		Destroy(gameObject, destroy);
		GameObject clone = GameObject.Find("ExpAnimator(Clone)");
		Destroy(clone);

	}

	void Update()
	{
		
		Vector3 pos = transform.position;
		if (Temp.x >= 0)
		{
			pos.x += speed * Time.deltaTime;
			transform.position = pos;
		}
		else if (Temp.x <= 0)
		{
			pos.x -= speed * Time.deltaTime;
			transform.position = pos;
		}		
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag != "Player")
        {			
			Instantiate(exposion,other.transform.position, transform.rotation);
			GameObject clone = GameObject.Find("ExpAnimator(Clone)");
			Destroy(clone, 1);
		}
    }
	


}

