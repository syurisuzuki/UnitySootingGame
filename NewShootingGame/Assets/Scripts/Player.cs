using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	// Spaceshipコンポーネント
	Spaceship spaceship;
		Score score;

		//アイテムゲット時のポイント（仮）
		public int itempoint = 400;
		private int ii = 1;

		public GameObject normalbullet;
		public GameObject rapidbullet;
		public GameObject strongbullet;
		public GameObject player;



		public bool specialbool = false;
		public GameObject[] SPB = new GameObject[9];
		private GameObject statetext;
		private string Pltext;
		private int SBLV = -1;
		public GameObject getanim;

		public GameObject options;

		private int optionhaves;
		private bool fulloption;

		Shotoption option;

	Bullet bullet;

		public enum PlayerState{
				PLAYER_NORMAL,
				PLAYER_RAPID,
				PLAYER_STRONG,
				PLAYER_SPECIAL,
				PLAYER_OPTION
		}
		private PlayerState state;

	IEnumerator Start ()
	{

		// Spaceshipコンポーネントを取得
		spaceship = GetComponent<Spaceship> ();
				bullet = GetComponent<Bullet> ();
				score = GetComponent<Score> ();
				option = GetComponent<Shotoption> ();
				optionhaves = 0;
				fulloption = false;
				state = PlayerState.PLAYER_NORMAL;
				spaceship.bullet = normalbullet;

		while (true) {
			
			// 弾をプレイヤーと同じ位置/角度で作成
			spaceship.Shot (transform);
			
			// ショット音を鳴らす
			audio.Play();
			
			// shotDelay秒待つ
						yield return new WaitForSeconds (spaceship.shotDelay+spaceship.baseshotDelay);
		}
	}
	
	void Update ()
	{
		// 右・左
		float x = Input.GetAxisRaw ("Horizontal");
		
		// 上・下
		float y = Input.GetAxisRaw ("Vertical");
		
		// 移動する向きを求める
		Vector2 direction = new Vector2 (x, y).normalized;
		
		// 移動の制限
		Move (direction);

				if(Input.GetKeyDown("f")){
						switch (state) {
						case PlayerState.PLAYER_NORMAL:
								state = PlayerState.PLAYER_RAPID;
								spaceship.bullet = rapidbullet;
								spaceship.speed = 5;
								spaceship.shotDelay = 0.05f;
								//bullet.power = 1;
								Pltext = "RAPID";
								FindObjectOfType<Score>().StateText(Pltext);
								break;
						case PlayerState.PLAYER_RAPID:
								state = PlayerState.PLAYER_STRONG;
								spaceship.bullet = strongbullet;
								spaceship.speed = 3;
								spaceship.shotDelay = 0.3f;
								//bullet.power = 7;
								Pltext = "STRONG";
								FindObjectOfType<Score>().StateText(Pltext);
								break;
						case PlayerState.PLAYER_STRONG:
								if(specialbool==true){
									state = PlayerState.PLAYER_SPECIAL;
										spaceship.bullet = SPB[SBLV];
										spaceship.speed = 4;
										spaceship.shotDelay = 0.25f;
										Pltext = "SPCIAL";
										FindObjectOfType<Score>().StateText(Pltext);
								}else{
									state = PlayerState.PLAYER_NORMAL;
									spaceship.bullet = normalbullet;
										spaceship.speed = 4;
										spaceship.shotDelay = 0.1f;
										Pltext = "NORMAL";
									FindObjectOfType<Score>().StateText(Pltext);
								}
								break;

						case PlayerState.PLAYER_SPECIAL:
								state = PlayerState.PLAYER_NORMAL;
								spaceship.bullet = normalbullet;
								spaceship.speed = 4;
								spaceship.shotDelay = 0.3f;
								Pltext = "NORMAL";
								FindObjectOfType<Score>().StateText(Pltext);
								break;

						}
				}
		
	}

	// 機体の移動
	void Move (Vector2 direction)
	{
		// 画面左下のワールド座標をビューポートから取得
				Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0.26f, 0));
		
		// 画面右上のワールド座標をビューポートから取得
				Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
		
		// プレイヤーの座標を取得
		Vector2 pos = transform.position;
		
		// 移動量を加える
				pos += direction  * spaceship.speed *spaceship.basespeed* Time.deltaTime;
		
		// プレイヤーの位置が画面内に収まるように制限をかける
		pos.x = Mathf.Clamp (pos.x, min.x, max.x);
		pos.y = Mathf.Clamp (pos.y, min.y, max.y);
		
		// 制限をかけた値をプレイヤーの位置とする
		transform.position = pos;
	}
	
	// ぶつかった瞬間に呼び出される
	void OnTriggerEnter2D (Collider2D c)
	{
		// レイヤー名を取得
		string layerName = LayerMask.LayerToName(c.gameObject.layer);

		
		// レイヤー名がBullet (Enemy)の時は弾を削除
		if( layerName == "Bullet (Enemy)")
		{
			// 弾の削除
			Destroy(c.gameObject);
		}

		// レイヤー名がBullet (Enemy)またはEnemyの場合は爆発
		if( layerName == "Bullet (Enemy)" || layerName == "Enemy")
		{
						spaceship.Explosion();
						Destroy (gameObject);
						FindObjectOfType<Manager>().Dead();
		}
				if(c.gameObject.tag == "scoreup"){
						GameObject itemget = (GameObject)Instantiate (getanim,transform.position, Quaternion.identity);
						itemget.transform.parent = transform;
						Destroy(c.gameObject);
						FindObjectOfType<Score>().AddPoint(itempoint);
				}


				//option追加
				if(c.gameObject.tag == "attackup"){
						GameObject itemget = (GameObject)Instantiate (getanim,transform.position, Quaternion.identity);
						itemget.transform.parent = transform;
						Destroy(c.gameObject);
						if(fulloption==false){
								GameObject s =(GameObject)Instantiate (options, transform.position, Quaternion.identity);
								s.transform.parent = transform;
								switch(optionhaves){
								case 0:
										optionhaves++;

										break;
								case 1:
										optionhaves++;
										s.transform.position *= 1.1f;
										break;
								case 2:
										optionhaves++;
										s.transform.position *= 0.9f;
										break;
								case 3:
										optionhaves++;
										s.transform.position *= 1.2f;
										break;
								case 4:
										optionhaves++;
										s.transform.position *= 0.8f;
										fulloption = true;
										break;
								default:
										FindObjectOfType<Score> ().AddPoint (itempoint);
										break;

								}

						}



				}

				if(c.gameObject.tag == "speedup"){
						GameObject itemget = (GameObject)Instantiate (getanim,transform.position, Quaternion.identity);
						itemget.transform.parent = transform;
						Destroy(c.gameObject);
						if(spaceship.basespeed<10){
								spaceship.basespeed += 0.1f;
						}else{
								Debug.Log ("speed MAX");
						}

				}

				if(c.gameObject.tag == "delayup"){
						GameObject itemget = (GameObject)Instantiate (getanim,transform.position, Quaternion.identity);
						itemget.transform.parent = transform;
						Destroy(c.gameObject);
						if(spaceship.shotDelay>0.1f){
								spaceship.baseshotDelay -= 0.01f;
						}else{
								Debug.Log ("shotdelay MAX");
						}
				}

				if(c.gameObject.tag == "lifeup"){
						GameObject itemget = (GameObject)Instantiate (getanim,transform.position, Quaternion.identity);
						itemget.transform.parent = transform;
						Destroy(c.gameObject);
						FindObjectOfType<Manager>().Zankiup();
				}

				if(c.gameObject.tag == "bulletlvup"){
						specialbool = true;
						GameObject itemget = (GameObject)Instantiate (getanim,transform.position, Quaternion.identity);
						itemget.transform.parent = transform;
						Destroy(c.gameObject);
						if(SBLV<8){
								state = PlayerState.PLAYER_SPECIAL;
								SBLV+=1;
								spaceship.bullet = SPB[SBLV];
								Pltext = "SPCIAL";
								FindObjectOfType<Score>().StateText(Pltext);
						}else{
								FindObjectOfType<Score>().AddPoint(itempoint);
						}

				}
	}
}