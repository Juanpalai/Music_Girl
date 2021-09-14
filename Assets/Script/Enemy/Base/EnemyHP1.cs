using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHP1 : MonoBehaviour
{

	// メンバ変数宣言
	public int health; // 体力
	Color color;
	private Rigidbody2D rigidbody2D = null;

	void Start()
	{
		color = GetComponent<SpriteRenderer>().material.color;
		rigidbody2D = GetComponent<Rigidbody2D>();
	}

	// 当たり判定内に他オブジェクトが侵入した際呼び出されるメソッド
	// 引数:接触オブジェクトしたオブジェクトのCollider情報
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.tag == "Ballet")
		{
			rigidbody2D.AddForce(new Vector2(200, 100));
			GetComponent<SpriteRenderer>().material.color = new Color32(255, 184, 184, 255);
			gameObject.transform.Rotate(0f, 0.0f, -90.0f);
			gameObject.transform.position = new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z );
			StartCoroutine(Attack());
			Destroy(collider.gameObject);
			health--;
		}
		// ボス消滅処理
		
	}
	IEnumerator Attack()
	{
		yield return new WaitForSeconds(0.2f);
		GetComponent<SpriteRenderer>().material.color = color;
		if (health <= 0)
		{// ボスの体力が0以下
			
			Destroy(gameObject); // 自オブジェクト消去

		}
	}
}