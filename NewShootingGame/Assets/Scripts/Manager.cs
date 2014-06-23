using UnityEngine;

public class Manager : MonoBehaviour
{
		public GameObject player;
		private GameObject title;
		private GameObject clear;
		private bool clearb;
		public KeyCode enter;
		public int zanki;
		private string ltext ="NORMAL";
	
		void Start (){
				title = GameObject.Find ("Title");
				clear = GameObject.Find ("Clear");
				clear.SetActive(false);
				clearb = false;
				}
	
		void Update ()
		{
		if (IsPlaying () == false && Input.GetKeyDown (KeyCode.X)) {
						GameStart ();
						}
				if(clearb ==true && Input.GetKeyDown(enter)){
						result ();
				}
						
				}
	
		void GameStart (){
				title.SetActive (false);
				FindObjectOfType<Score>().StateText(ltext);
				zanki = 5;
				FindObjectOfType<Score>().Zanki(zanki);
				Instantiate (player, player.transform.position, player.transform.rotation);
				}
	
		public void GameOver (){
				FindObjectOfType<Score>().Save();
				FindObjectOfType<Emitter>().rest();
				title.SetActive (true);
				}

		public void GameClear(){
				/*FindObjectOfType<Score>().Save();
				FindObjectOfType<Emitter>().rest();*/
				//title.SetActive (true);
				clearb = true;
				clear.SetActive (true);
		}

		public void result(){
				Debug.Log ("re");
				FindObjectOfType<Score>().Save();
				FindObjectOfType<Emitter>().rest();
				clear.SetActive (false);
				clearb = false;
				GameStart ();
		}

		public void Dead(){
				zanki--;
				if(zanki == 0){
						GameOver ();
						FindObjectOfType<Score>().Zanki(zanki);
				}else{
						Instantiate (player, player.transform.position, player.transform.rotation);
						FindObjectOfType<Score>().Zanki(zanki);
						}
				}
		public void Zankiup(){
				zanki += 1;
				FindObjectOfType<Score>().Zanki(zanki);
				}

		public void Zankidown(){
				zanki -= 1;
				FindObjectOfType<Score>().Zanki(zanki);
				}
	
		public bool IsPlaying (){
		return title.activeSelf == false;
				}

		public bool ClearGame(){
				return clear.activeSelf == true;
		}
		}