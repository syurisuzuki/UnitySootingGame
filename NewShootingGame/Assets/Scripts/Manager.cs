using UnityEngine;

public class Manager : MonoBehaviour
{
	// Playerプレハブ
	public GameObject player;
	// タイトル
	private GameObject title;
		public int zanki;
		private string ltext ="NORMAL";
	
	void Start ()
	{


		// Titleゲームオブジェクトを検索し取得する
		title = GameObject.Find ("Title");

	}
	
	void Update ()
	{
		// ゲーム中ではなく、Xキーが押されたらtrueを返す。
		if (IsPlaying () == false && Input.GetKeyDown (KeyCode.X)) {

			GameStart ();
		}
	}
	
	void GameStart ()
	{
		// ゲームスタート時に、タイトルを非表示にしてプレイヤーを作成する

		title.SetActive (false);
				FindObjectOfType<Score>().StateText(ltext);
				zanki = 5;
				FindObjectOfType<Score>().Zanki(zanki);
				Instantiate (player, player.transform.position, player.transform.rotation);
	}
	
	public void GameOver ()
	{
		FindObjectOfType<Score>().Save();
				FindObjectOfType<Emitter>().rest();
		// ゲームオーバー時に、タイトルを表示する
		title.SetActive (true);
	}

		public void Dead(){
				//FindObjectOfType<Score>().StateText(ltext);
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
	
	public bool IsPlaying ()
	{
		// ゲーム中かどうかはタイトルの表示/非表示で判断する
		return title.activeSelf == false;
	}
}