using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMove : MonoBehaviour
{
	private Rigidbody2D _rd;
	private Animator _ra = null;
	[SerializeField]
	private int HP = 3;
	public float speed = 4f;//歩くスピ�EチE


	private bool _dashAttack_trigger = false;
	private bool isAnim = false;

	//public Vector3 SPEED = new Vector3(0.05f, 0.05f, 0.05f);
	public Vector3 JUMP = new Vector3(0.05f, 0.05f, 0.05f);
	void Start()
	{

	}

	void Update()
	{
		_rd = GetComponent<Rigidbody2D>();
		_ra = GetComponent<Animator>();

	    isAnim = _ra.GetCurrentAnimatorStateInfo(0).IsName("Damege");

        Vector3 Position = transform.position;
        if (Input.GetKey("up"))
		{
			Position.y += JUMP.y;
		}
		if (Input.GetKey(KeyCode.S) && !_dashAttack_trigger )
		{
			_ra.SetBool("Attack", true);
		}
		else
		{
			_ra.SetBool("Attack", false);
		}

		if (Input.GetKey("left"))
		{
			_dashAttack_trigger = true;
			//Position.x -= SPEED.x;
			_ra.SetBool("Walk", true);

		}
		else if (Input.GetKey("right"))
		{
			_dashAttack_trigger = true;
			//Position.x += SPEED.x;
			_ra.SetBool("Walk", true);
			
		}
		else
		{
			_dashAttack_trigger = false;
			_ra.SetBool("Walk", false);
		}

			if (Input.GetKey(KeyCode.S) && _dashAttack_trigger)
			{
			
				_ra.SetBool("DashAttack", true);
			}
			else
			{
				_ra.SetBool("DashAttack", false);
			}

		float x = Input.GetAxisRaw("Horizontal");
		// チE��ォルトが右向きの画像�E場吁E
		// スケール値取り出ぁE
		//Vector3 scale = transform.localScale;
		//if (x >= 0)
		//{
		//	// 右方向に移動中
		//	scale.x = 1; // そ�Eまま�E�右向き�E�E
		//}
		//else
		//{
		//	// 左方向に移動中
		//	scale.x = -1; // 反転する�E�左向き�E�E
		//}
		//// 代入し直ぁE
		//transform.localScale = scale;

		//transform.position = Position;


		//キャラクターの向き関連------------------------------------------------------------------------------------------
		if (x != 0)
		{
			//入力方向へ移勁E
			_rd.velocity = new Vector2(x * speed, _rd.velocity.y);
			//localScale.xめE1にすると画像が反転する
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
			//左も右も�E力してぁE��かったら
		}
		else
		{
			//横移動�E速度めEにしてピタチE��止まるよぁE��する
			_rd.velocity = new Vector2(0, _rd.velocity.y);
		}
		//----------------------------------------------------------------------------------------------------------------

	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (1 <= HP && !isAnim )
		{
			string tag = collision.gameObject.tag;
			if (tag == "Spike")
			{
				_ra.SetBool("Damege", true);
				HP--;
			}
		
		}

		if( HP <= 0)
        {

			die();
        }
	}

	private void die()
	{
		Destroy(this.gameObject);
	}
	private void DamegeBoool()
	{
			_ra.SetBool("Damege", false);
	}
}