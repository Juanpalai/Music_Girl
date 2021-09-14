using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;//NavMeshagentを使うために記述する

public class Enemy : MonoBehaviour
{

	public GameObject warning_text;
	public float EnemyRange;//警戒範囲の値の設定
	public Vector3[] wayPoints = new Vector3[3];//徘徊するポイントの座標を代入するVector3型の変数を配列で作る
	private int currentRoot;//現在目指すポイントを代入する変数
	private int Mode;//敵の行動パターンを分けるための変数
	public Transform player;//プレイヤーの位置を取得するためのTransform型の変数
	public Transform enemypos;//敵の位置を取得するためのTransform型の変数
	private NavMeshAgent agent;//NavMeshAgentの情報を取得するためのNavmeshagent型の変数

	void Start()
	{
		warning_text.SetActive(false);
		agent = GetComponent<NavMeshAgent>();//NavMeshAgentの情報をagentに代入
	}

	void Update()
	{
		Vector3 pos = wayPoints[currentRoot];//Vector3型のposに現在の目的地の座標を代入
		float distance = Vector3.Distance(enemypos.position, player.transform.position);//敵とプレイヤーの距離を求める

		if (distance > EnemyRange)
		{//もしプレイヤーと敵の距離が5以上なら
			Mode = 0;//Modeを0にする
		}

		if (distance < EnemyRange)
		{//もしプレイヤーと敵の距離が5以下なら
			Mode = 1;//Modeを1にする
		}

		switch (Mode)
		{//Modeの切り替えは

			case 0://case0の場合

				warning_text.SetActive(false);

				if (Vector3.Distance(transform.position, pos) < 1f)
				{//もし敵の位置と現在の目的地との距離が1以下なら
					currentRoot += 1;//currentRootを+1する
					if (currentRoot > wayPoints.Length - 1)
					{//もしcurrentRootがwayPointsの要素数-1より大きいなら
						currentRoot = 0;//currentRootを0にする
					}
				}
				GetComponent<NavMeshAgent>().SetDestination(pos);//NavMeshAgentの情報を取得し目的地をposにする
				break;//switch文の各パターンの最後につける

			case 1://case1の場合

				warning_text.SetActive(true);

				agent.destination = player.transform.position;//プレイヤーに向かって進む		
				break;//switch文の各パターンの最後につける
		}
	}
}