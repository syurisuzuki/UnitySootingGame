using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
		Shotoption option;
		Bullet bullet;
		Spaceship spaceship;
		Score score;
		public int itempoint = 400;
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

		public enum PlayerState{
				PLAYER_NORMAL,
				PLAYER_RAPID,
				PLAYER_STRONG,
				PLAYER_SPECIAL,
				PLAYER_OPTION
		}
		private PlayerState state;

		IEnumerator Start (){
				spaceship = GetComponent<Spaceship> ();
				bullet = GetComponent<Bullet> ();
				score = GetComponent<Score> ();
				option = GetComponent<Shotoption> ();
				optionhaves = 0;
				fulloption = false;
				state = PlayerState.PLAYER_NORMAL;
				spaceship.bullet = normalbullet;

				while (true) {
						spaceship.Shot (transform);
						audio.Play();
						yield return new WaitForSeconds (spaceship.shotDelay+spaceship.baseshotDelay);
						}
				}
	
		void Update (){
				float x = Input.GetAxisRaw ("Horizontal");
				float y = Input.GetAxisRaw ("Vertical");
				Vector2 direction = new Vector2 (x, y).normalized;
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

		void Move (Vector2 direction){
				Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0.26f, 0));
				Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
				Vector2 pos = transform.position;
				pos += direction  * spaceship.speed *spaceship.basespeed* Time.deltaTime;
				pos.x = Mathf.Clamp (pos.x, min.x, max.x);
				pos.y = Mathf.Clamp (pos.y, min.y, max.y);
				transform.position = pos;
				}
		void OnTriggerEnter2D (Collider2D c){
				string layerName = LayerMask.LayerToName(c.gameObject.layer);
				if( layerName == "Bullet (Enemy)"){
						Destroy(c.gameObject);
						}
				if( layerName == "Bullet (Enemy)" || layerName == "Enemy"){
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