using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterMove : MonoBehaviour
{
	private Rigidbody2D _rd;
	private Animator _ra = null;
	[SerializeField]
	private int HP = 3;
	public float speed = 4f;//豁ｩ縺上せ繝斐・繝・


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
		// 繝・ヵ繧ｩ繝ｫ繝医′蜿ｳ蜷代″縺ｮ逕ｻ蜒上・蝣ｴ蜷・
		// 繧ｹ繧ｱ繝ｼ繝ｫ蛟､蜿悶ｊ蜃ｺ縺・
		//Vector3 scale = transform.localScale;
		//if (x >= 0)
		//{
		//	// 蜿ｳ譁ｹ蜷代↓遘ｻ蜍穂ｸｭ
		//	scale.x = 1; // 縺昴・縺ｾ縺ｾ・亥承蜷代″・・
		//}
		//else
		//{
		//	// 蟾ｦ譁ｹ蜷代↓遘ｻ蜍穂ｸｭ
		//	scale.x = -1; // 蜿崎ｻ｢縺吶ｋ・亥ｷｦ蜷代″・・
		//}
		//// 莉｣蜈･縺礼峩縺・
		//transform.localScale = scale;

		//transform.position = Position;


		//繧ｭ繝｣繝ｩ繧ｯ繧ｿ繝ｼ縺ｮ蜷代″髢｢騾｣------------------------------------------------------------------------------------------
		if (x != 0)
		{
			//蜈･蜉帶婿蜷代∈遘ｻ蜍・
			_rd.velocity = new Vector2(x * speed, _rd.velocity.y);
			//localScale.x繧・1縺ｫ縺吶ｋ縺ｨ逕ｻ蜒上′蜿崎ｻ｢縺吶ｋ
			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;
			//蟾ｦ繧ょ承繧ょ・蜉帙＠縺ｦ縺・↑縺九▲縺溘ｉ
		}
		else
		{
			//讓ｪ遘ｻ蜍輔・騾溷ｺｦ繧・縺ｫ縺励※繝斐ち繝・→豁｢縺ｾ繧九ｈ縺・↓縺吶ｋ
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