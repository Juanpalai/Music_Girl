using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DanettoBallet : MonoBehaviour
{
	// 変数宣言
	[SerializeField] private float speed = 3.0f; // スピード
	[SerializeField] private int destroy = 2;

	// 起動時に１回だけ呼び出されるメソッド
	void Start()
	{

		Destroy(gameObject, destroy);
	}

	void Update()
	{
		Vector3 pos = transform.position;
		
		pos.x -= speed * Time.deltaTime;
		transform.position = pos;
		
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			FindObjectOfType<PlayerController>().Damage();
			Destroy(gameObject);
		}
	}
}
