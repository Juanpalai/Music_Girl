using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

	// メンバ変数宣言
	public int health; // 体力
	private AudioSource Explosion;
	Color color;
	private Rigidbody2D rigidbody2D = null;
	float save;

	void Start()
	{
		Explosion = GameObject.Find("Explosion").GetComponent<AudioSource>();
		color = GetComponent<SpriteRenderer>().material.color;
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// 当たり判定内に他オブジェクトが侵入した際呼び出されるメソッド
	// 引数:接触オブジェクトしたオブジェクトのCollider情報
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Ballet")
		{
			health--;
			save = FindObjectOfType<AmpController>().speed; 
			FindObjectOfType<AmpController>().speed = 2;
			rigidbody2D.AddForce(new Vector2(-500, 200));
			GetComponent<SpriteRenderer>().material.color = new Color32(255, 184, 184, 255);
			if (health <= 0)
			{// ボスの体力が0以下
				gameObject.transform.Rotate(0f, 0.0f, -90.0f);

			}
			StartCoroutine(Attack());
			Destroy(collider.gameObject);
			
		}
		if (collider.tag == "Ballet2")
		{
			Destroy(collider.gameObject);
			health = health - 2;
			Explosion.Play();
			if (health <= 0)
			{// ボスの体力が0以下
				Destroy(gameObject); // 自オブジェクト消去

			}
		}
		// ボス消滅処理

	}
	IEnumerator Attack()
	{
		yield return new WaitForSeconds(0.7f);
		GetComponent<SpriteRenderer>().material.color = color;
		FindObjectOfType<AmpController>().speed = save;
		if (health <= 0)
		{// ボスの体力が0以下			
			Destroy(gameObject); // 自オブジェクト消去

		}
	}
}
