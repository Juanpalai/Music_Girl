using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Fender : MonoBehaviour
{
	public Object wind;
	Color color;
	public int HP;
	private int defaltHP;
	bool wind_active = false;
	public EnemyHP enemyHP;

    void Start()
    {
        defaltHP = HP;
		color = GetComponent<SpriteRenderer>().material.color;
	}

    void Update()
    {
		if(defaltHP/2 >= HP && wind_active == false)
		{
			Instantiate(wind);
			wind_active = true;
		}

        
    }

	void OnTriggerEnter2D(Collider2D collider)
	{

		if (collider.gameObject.tag == "Ballet")
		{
			GetComponent<SpriteRenderer>().material.color = new Color32(255, 184, 184, 255);
			StartCoroutine(Attack());
			HP--;

			Destroy(collider.gameObject);
		}
		if (collider.gameObject.tag == "Ballet2")
		{
			GetComponent<SpriteRenderer>().material.color = new Color32(255, 184, 184, 255);
			StartCoroutine(Attack());
			HP = HP - 2;

			Destroy(collider.gameObject);
		}
		FindObjectOfType<HealthBar2>().SetHealth(HP);
		if (HP <= 0)
		{
			Destroy(collider.gameObject);
			StartCoroutine(Change());
			SceneManager.LoadScene("GameClear");
		}
		IEnumerator Change()
		{ yield return new WaitForSeconds(1f) ;
		} 
	}

		IEnumerator Attack()
		{
			yield return new WaitForSeconds(0.2f);
			GetComponent<SpriteRenderer>().material.color = color;
			if (HP == 0)
			{
				Destroy(this.gameObject);
			}
				;
		}
	}

