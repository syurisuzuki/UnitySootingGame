using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{
		public int hp = 1;
		public int point = 10;
		Spaceship spaceship;
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
				spaceship = GetComponent<Spaceship> ();
				Move (transform.up * -1);
				if (spaceship.canShot == false) {
						yield break;
				}
			
				while (true) {
						for (int i = 0; i < transform.childCount; i++) {
								Transform shotPosition = transform.GetChild (i);
								spaceship.Shot (shotPosition);
								}
						yield return new WaitForSeconds (spaceship.shotDelay);
						}
				}

		public void Move (Vector2 direction){
				rigidbody2D.velocity = direction * spaceship.speed;
				}

		void Update(){
				enemypo = transform.position;
				if(boss==true){
						FindObjectOfType<Score>().Hpchenge(hp);
						}
				}

		void OnTriggerEnter2D (Collider2D c){
				/*	Debug.Log("collision!!");*/
				string layerName = LayerMask.LayerToName (c.gameObject.layer);
				if(layerName == "Bullet (option)"){
						Transform optionBulletTranceform = c.transform.parent;
						Bullet opbullet = optionBulletTranceform.GetComponent<Bullet> ();
						hp = hp - opbullet.power;
						Destroy(c.gameObject);
						}
				if (layerName != "Bullet (Player)") return;
				Transform playerBulletTransform = c.transform.parent;
				Bullet bullet =  playerBulletTransform.GetComponent<Bullet>();
				hp = hp - bullet.power;
				Destroy(c.gameObject);
				if(hp <= 0 ){
						FindObjectOfType<Score>().AddPoint(point);
						spaceship.Explosion ();
						itempos = transform.position;
						Destroy (gameObject);

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
										/*Debug.Log (j);*/
										break;
								}
						}


				}else{
						spaceship.GetAnimator().SetTrigger("Damage");
						}
				}

		}