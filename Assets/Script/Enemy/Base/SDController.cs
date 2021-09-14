using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class SDController : MonoBehaviour
{

	// 移動速度
	[SerializeField]
	private float speed = 2.0f;
	[SerializeField]
	private float attackSpeed = 3.0f;
	[SerializeField]
	private float moveRenge = 4.0f;
	[SerializeField]
	private float rangeOfCaution = 2;//警戒範囲
	public Transform player;
	public Transform enemypos;
	private Animator anim;
	private Vector3 pos;//初期位置
	private int mode = 0;

	// Rigidbody
	private Rigidbody2D rb;

	void Start()
	{

		rb = GetComponent<Rigidbody2D>();
		pos = transform.position;
		anim = GetComponent<Animator>();

	}

	void Update()
	{

		float distance = Vector3.Distance(enemypos.position, player.transform.position);//敵とプレイヤーの距離を求める


		if (distance > rangeOfCaution)
		{
			//もしプレイヤーと敵のrangeOfCautionが以上なら
			anim.SetBool("Attack", false);
			move();

		}

		if (distance < rangeOfCaution)
		{
			//もしプレイヤーと敵の距離がrangeOfCaution以下なら
			anim.SetBool("Attack", true);
			AttackMove();
		}

		switch (mode)
		{
			case 0:
				if (transform.position.x > pos.x + moveRenge)
				{
					Inversion();

					mode = 1;
				}
				break;
			case 1:
				if (transform.position.x < pos.x - moveRenge)
				{
					Inversion();

					mode = 0;
				}
				break;
		}
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		string tag = collision.gameObject.tag;
		if (tag == "Player")
		{
			Inversion();
			mode += 1;
			if (mode >= 2)
			{
				mode = 0;
			}
		}
	}


	private void move()
	{
		rb.velocity = new Vector2(speed, rb.velocity.y);
	}


	private void AttackMove()
	{
		rb.velocity = new Vector2(attackSpeed, rb.velocity.y);
	}


	private void Inversion()
	{
		speed = speed * -1f;
		attackSpeed = attackSpeed * -1f;
	}
}