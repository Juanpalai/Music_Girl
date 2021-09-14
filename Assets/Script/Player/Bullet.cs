using UnityEngine;
public class Bullet : MonoBehaviour
{   // 変数宣言
	[SerializeField] private float speed = 3.0f; // スピード
	[SerializeField] private int destroy = 1;//消滅
	private GameObject player;
	private Vector2 Temp;
	


	// 起動時に１回だけ呼び出されるメソッド
	void Start()
	{
		player = GameObject.Find("syuzinkou_taiki");
		
		Vector2 temp = transform.localScale;
		temp.x = player.transform.localScale.x;
		Temp = temp;
		transform.localScale = temp;
		Destroy(gameObject, 1.5f);		
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

}
