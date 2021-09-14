using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class BossHP : MonoBehaviour
{
	// メンバ変数宣言
	public int health; // 体力	
	Color color;	

	public GameObject BosuHP;

	void Start()
	{
		color = GetComponent<SpriteRenderer>().material.color;
	}

	void Update()
	{
		if (health <= 0)
		{// ボスの体力が0以下
			
			BosuHP.SetActive(false);
		}
	
	}
	//当たり判定内に他オブジェクトが侵入した際呼び出されるメソッド
	//引数:接触オブジェクトしたオブジェクトのCollider情報
	void OnTriggerEnter2D(Collider2D collider)
	{
		// 弾オブジェクトを消滅させる

		

		// 自身の体力を1減らす
		if (collider.tag == "Ballet")
			{
			GetComponent<SpriteRenderer>().material.color = new Color32(255, 184, 184, 255);
			StartCoroutine(Attack());
			Destroy(collider.gameObject);
			health--;
			}		
		FindObjectOfType<HealthBar>().SetHealth(health);
		// ボス消滅処理
		
	}

	IEnumerator Attack()
	{
		yield return new WaitForSeconds(0.2f);
		GetComponent<SpriteRenderer>().material.color = color;		
		if (health <= 0)		{// ボスの体力が0以下			
			FindObjectOfType<PlayerController>().cam = true;
			FindObjectOfType<PlayerController>().redmegafone = true;
			FindObjectOfType<Megafone>().redmegafone = true;
			FindObjectOfType<SwitchMusicTrigger>().BosuHP.SetActive(false);
			FindObjectOfType<PlayerController>().cam = false;
			Destroy(this.gameObject);		

		}
	}

	
}

