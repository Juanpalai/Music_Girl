using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Boss2Ballet : MonoBehaviour
{
	// 変数宣言
	public float sterSpeed;
	[SerializeField] private float speed = 3.0f; // スピード
	[SerializeField] private int destroy = 2;

	// 起動時に１回だけ呼び出されるメソッド
	void Start()
	{

		Destroy(gameObject, destroy);
	}

	void Update()
	{
		this.transform.Rotate(new Vector3(0, 0, 1),sterSpeed);
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
