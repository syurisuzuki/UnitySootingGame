using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
	public int hp = 1;
	public int point = 10;

	Spaceship spaceship;
		//item
		public GameObject ScoreUpItem;
		public GameObject SpeedupUpItem;
		public GameObject LifeUpItem;
		public GameObject DelayUpItem;
		public GameObject ModelChengeItem;
		private Vector2 itempos;
		public bool boss;
		private int bosshp;
		public Vector3 enemypo;

	IEnumerator Start ()
	{
		
		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship> ();
		
		// ローカル座標のY軸のマイナス方向に移動する
		Move (transform.up * -1);
		
		// canShotがfalseの場合、ここでコルーチンを終了させる
		if (spaceship.canShot == false) {
			yield break;
		}
			
		while (true) {
			
			// 子要素を全て取得する
			for (int i = 0; i < transform.childCount; i++) {
				
				Transform shotPosition = transform.GetChild (i);
				
				// ShotPositionの位置/角度で弾を撃つ
				spaceship.Shot (shotPosition);
			}
			
			// shotDelay秒待つ
			yield return new WaitForSeconds (spaceship.shotDelay);
		}
	}

	// 機体の移動
	public void Move (Vector2 direction)
	{
		rigidbody2D.velocity = direction * spaceship.speed;
	}
		void Update(){

				enemypo = transform.position;
				//Debug.Log (enemypo);
				if(boss==true){
						FindObjectOfType<Score>().Hpchenge(hp);
				}
		}

	void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名を取得
				Debug.Log("collision!!");
		string layerName = LayerMask.LayerToName (c.gameObject.layer);
		
		// レイヤー名がBullet (Player)以外の時は何も行わない

				if(layerName == "Bullet (option)"){
						Transform optionBulletTranceform = c.transform.parent;
						Bullet opbullet = optionBulletTranceform.GetComponent<Bullet> ();
						hp = hp - opbullet.power;
						Destroy(c.gameObject);
				}
						
				if (layerName != "Bullet (Player)") return;

		// PlayerBulletのTransformを取得

						Transform playerBulletTransform = c.transform.parent;
						Bullet bullet =  playerBulletTransform.GetComponent<Bullet>();
						hp = hp - bullet.power;
						
		


		// Bulletコンポーネントを取得
		


		// ヒットポイントを減らす


		// 弾の削除
		Destroy(c.gameObject);

		// ヒットポイントが0以下であれば
		if(hp <= 0 )
		{
			// スコアコンポーネントを取得してポイントを追加
			FindObjectOfType<Score>().AddPoint(point);

			// 爆発
			spaceship.Explosion ();
						//ポジション取得
						itempos = transform.position;

			// エネミーの削除
			Destroy (gameObject);

						//アイテム出現
						int k = Random.Range (1, 4);
						for(int i = 0;i<k;i++){
								int j = Random.Range (1, 6);
								switch(j){
								case 1:
										Instantiate (ScoreUpItem, itempos, transform.rotation);
										break;
								case 2:
										Instantiate (SpeedupUpItem, itempos, transform.rotation);
										break;
								case 3:
										Instantiate (DelayUpItem, itempos, transform.rotation);
										break;
								case 4:
										Instantiate (ModelChengeItem, itempos, transform.rotation);
										break;
								case 5:
										Instantiate (LifeUpItem, itempos, transform.rotation);
										break;
								default:
										Debug.Log (j);
										break;
								}
						}


		}else{
			// Damageトリガーをセット
			spaceship.GetAnimator().SetTrigger("Damage");
		
		}
	}

}