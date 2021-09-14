using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	[SerializeField]
	public int HP = 3;
	public float speed = 4f;
	public float jumpPower = 700; 
	public LayerMask groundLayer;//Linecastで判定するLayer
	public GameObject mainCamera;
	public GameObject bullet1;
	public GameObject bullet2;	
	public bool live;
	public bool cam;
	public bool down;
	public bool redmegafone;	
	bool attacking;
	public bool pause;

	//Songs------------------------------

	[SerializeField] private AudioSource Atack;
	[SerializeField] private AudioSource Atack2;
	[SerializeField] private AudioSource Jump;
	[SerializeField] private AudioSource Dmagea;
	[SerializeField] private AudioSource Chance;
	//[SerializeField] private AudioSource Atack;

	private Rigidbody2D rigidbody2D = null;
	private Animator anim;
	public bool isGrounded;//着地判定
	private bool walkTrigger;
	private int atack = 1;
	private GameObject _bullet;

	//アニメーションのbool------------------
	private bool isAnim = false;
	private bool atkAnim = false;
	private bool d_atkAnim = false;
	private bool j_Anim = false;
	private bool j_atkAnim = false;
	//--------------------------------------


	void Start()
    {
        anim = GetComponent<Animator>();
		rigidbody2D = GetComponent<Rigidbody2D>();
		walkTrigger = false;
		_bullet = bullet1;
		live = true;
		redmegafone = false;
		down = false;
		cam = false;
		pause = false;
		Time.timeScale = 1f;
		if (Stageselec.stage == 1)
        {
			//transform.position = new Vector3(-4.07f, -2.13f, 0f);
        }
		if(Stageselec.stage == 2)
        {
			redmegafone = true;
			down = true;
			FindObjectOfType<Megafone>().redmegafone = true;
			transform.position = new Vector3(212.89f, -16.81f, 0f);
		}
	}


	void Update()
	{
		if (transform.position.x < mainCamera.transform.position.x + 4 && !cam)
		{
			Vector3 cameraPos2 = mainCamera.transform.position;
			//Playerの位置から右に4移動した位置を画面中央にする
			//cameraPos2.y = transform.position.y - 2;
			cameraPos2.x = transform.position.x - 4;
			mainCamera.transform.position = cameraPos2;
		}
		if (transform.position.x > mainCamera.transform.position.x - 4 && !cam)
		{
			//カメラの位置を取得
			Vector3 cameraPos2 = mainCamera.transform.position;
			//Playerの位置から右に4移動した位置を画面中央にする
			//cameraPos2.y = transform.position.y - 2;
			cameraPos2.x = transform.position.x + 4;
			mainCamera.transform.position = cameraPos2;
		}

		Vector3 cameraPos = mainCamera.transform.position;
		if (transform.position.y < mainCamera.transform.position.y - 2.5 && redmegafone)
		{
			cameraPos.y = transform.position.y + 2.5f;
			mainCamera.transform.position = cameraPos;
		}

		if (Input.GetKeyDown(KeyCode.Escape) && !pause)
		{
			FindObjectOfType<Puse>().pause = true;
			pause = true;
		}
		if (pause)
        {
			Time.timeScale = 0F;
		}
		
		//アニメーション再生状態のbool判定---------------------------------------

		isAnim = anim.GetCurrentAnimatorStateInfo(0).IsName("Damege");
		atkAnim = anim.GetCurrentAnimatorStateInfo(0).IsName("Attack");
		d_atkAnim = anim.GetCurrentAnimatorStateInfo(0).IsName("DashAttack");
		j_Anim = anim.GetCurrentAnimatorStateInfo(0).IsName("Jump");
		j_atkAnim = anim.GetCurrentAnimatorStateInfo(0).IsName("JumpAttack");

		//ジャンプ---------------------------------------------------------------

		//LinecastでPlayerの足元に地面があるか判定
		isGrounded = Physics2D.Linecast(
		transform.position + transform.up * 1,
		transform.position - transform.up * 2.0f,
		groundLayer);

		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (isGrounded)
			{
				anim.SetBool("Walk", false);
				isGrounded = false;
				Jump.Play();
				rigidbody2D.AddForce(Vector2.up * jumpPower);
			}

		}


		float velY = rigidbody2D.velocity.y;

		bool isJumping = velY > 0.1f ? true : false;

		bool isFalling = velY < -0.1f ? true : false;

		if( !isGrounded)
		{
			anim.SetBool("Jump", true);
		}
		else
		{
			anim.SetBool("Jump", false);
		}
		//-----------------------------------------------------------------------

		
		if (Input.GetKeyDown(KeyCode.F) && redmegafone)
        {
			Chance.Play();
			if(atack ==1)
            {
				atack = 2;
				_bullet = bullet2;
				return;
				
			}
			if (atack == 2)
			{
				atack = 1;
				_bullet = bullet1;
				return;
				
			}
		}

		//弾--------------------------------------------------------------------
		if ( !j_atkAnim && !d_atkAnim && !atkAnim && Input.GetKeyDown( KeyCode.S ) && live)
		{
			//flahs.Play();
			if (!attacking) StartCoroutine(Attack());
		}
		//-----------------------------------------------------------------------

	}

    
    void FixedUpdate()
    {
		float x = Input.GetAxisRaw( "Horizontal" );
		
		//止まっていなかったら
		if(x != 0 && live){ 
			walkTrigger = true;
			rigidbody2D.velocity = new Vector2( x * speed, rigidbody2D.velocity.y );

			Vector2 temp = transform.localScale;
			temp.x = x;
			transform.localScale = temp;

			if (isGrounded)
			{
				anim.SetBool("Walk", true);
			}else if (!isGrounded)
			{
				anim.SetBool("Walk", false);
			}

			//カメラ関係--------------------------------------------------------------

			//画面中央から左に4移動した位置をPlayerが超えたら
			
		
			


			//カメラ表示領域の左下をワールド座標に変換
			Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
			//カメラ表示領域の右上をワールド座標に変換
			Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
			//Playerのポジションを取得
			Vector2 pos = transform.position;
			//Playerのx座標の移動範囲をClampメソッドで制限
			pos.x = Mathf.Clamp(pos.x, min.x + 0.5f, max.x);
			transform.position = pos;

			//------------------------------------------------------------------------

		}
		else{
			walkTrigger = false;
			rigidbody2D.velocity = new Vector2(0, rigidbody2D.velocity.y);
			
			anim.SetBool("Walk", false);
			
		}
        
    }

	private void OnCollisionEnter2D(Collision2D collision)
	{

		//HP---------------------------------------------------------------------

		if (1 <= HP && !isAnim)
		{
			string tag = collision.gameObject.tag;
			if (tag == "Spike")
			{
				
				Damage();
			}

		}
		//-----------------------------------------------------------------------
	}
	

	public void Damage()
    {
		Dmagea.Play();
		anim.SetTrigger("Damege");
		HP--;
		rigidbody2D.AddForce(new Vector2(-500, 200));

		switch (HP)
		{
			case 9:
				GameObject.Find("Heart 10").GetComponent<Image>().color = new Color32(255, 255, 225, 100);
				break;
			case 8:
				GameObject.Find("Heart 9").GetComponent<Image>().color = new Color32(255, 255, 225, 100);
				break;
			case 7:
				GameObject.Find("Heart 8").GetComponent<Image>().color = new Color32(255, 255, 225, 100);
				break;
			case 6:
				GameObject.Find("Heart 7").GetComponent<Image>().color = new Color32(255, 255, 225, 100);
				break;
			case 5:
				GameObject.Find("Heart 6").GetComponent<Image>().color = new Color32(255, 255, 225, 100);
				break;
			case 4:
				GameObject.Find("Heart 5").GetComponent<Image>().color = new Color32(255, 255, 225, 100);
				break;
			case 3:
				GameObject.Find("Heart 4").GetComponent<Image>().color = new Color32(255, 255, 225, 100);
				break;
			case 2:
				GameObject.Find("Heart 3").GetComponent<Image>().color = new Color32(255, 255, 225, 100);
				break;
			case 1:
				GameObject.Find("Heart 2").GetComponent<Image>().color = new Color32(255, 255, 225, 100);
				break;
			case 0:
				GameObject.Find("Heart 1").GetComponent<Image>().color = new Color32(255, 255, 225, 100);
				break;

		}
		if (HP <= 0)
		{
			GameObject.Find("Panel").GetComponent<Animator>().SetBool("Exit", true);
			StartCoroutine(Die());
		}
	}
	
	public void comeback()
	{
		if (HP > 0)
		{
			transform.position = GameObject.Find("reset1").transform.position;
			down = false;
		}
		else
		{
			Destroy(GameObject.Find("down"));
			
		}
	}
	public void comeback2()
	{
		if (HP > 0)
		{
			transform.position = GameObject.Find("reset2").transform.position;
			down = false;
		}
		else
		{
			Destroy(GameObject.Find("down2"));
			
		}
	}
	public void comeback3()
	{
		if (HP > 0)
		{
			transform.position = GameObject.Find("reset3").transform.position;
			down = false;
		}
		else
		{
			Destroy(GameObject.Find("downe"));
			
		}
	}
	public void comeback4()
	{
		if (HP > 0)
		{
			transform.position = GameObject.Find("reset4").transform.position;
			down = false;
		}
		else
		{
			Destroy(GameObject.Find("downe4"));
			
		}
	}

	public void comeback5()
	{
		if (HP > 0)
		{
			transform.position = GameObject.Find("reset5").transform.position;
			down = false;
		}
		else
		{
			Destroy(GameObject.Find("downe5"));
			
		}
	}
	IEnumerator Attack()
	{
		attacking = true;

		if (atack == 1)
		{
			Atack.Play();
			_bullet = bullet1;

		}
		if (atack == 2)
		{
			Atack2.Play();
			_bullet = bullet2;

		}


		if (isGrounded)
		{
			if (!walkTrigger)
			{
				anim.SetTrigger("Attack");
			}
			else if (walkTrigger)
			{
				anim.SetTrigger("DashAttack");
			}
		}
		else if (!isGrounded)
		{
			anim.SetTrigger("JumpAttack");
		}
		
		Instantiate(_bullet, transform.position + new Vector3(0f, 0.6f, 0f), transform.rotation);


		_bullet = null;
		yield return new WaitForSeconds(1f);
		attacking = false;
	}
	IEnumerator Die()
	{

		if (!down)
		{
			gameObject.transform.Rotate(0f, 0.0f, 55.0f);
		}				
		float time1, time2;
		time1 = Time.timeScale;
		time2 = Time.fixedDeltaTime;
		live = false;
		Time.timeScale = 0.5f;
		//Time.fixedDeltaTime = Time.timeScale * 0.1f;
		yield return new WaitForSeconds(.6f);
		Destroy(this.gameObject);
		Time.timeScale = time1;
		Time.fixedDeltaTime = time2;
		SceneManager.LoadScene("GameO");
	}


}

