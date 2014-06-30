using UnityEngine;

public class Score : MonoBehaviour
{
		public GUIText scoreGUIText;
		public GUIText highScoreGUIText;
		public GUIText playerstate;
		public GUIText enemyHP;
		public GUIText zankit;
		public GUIText resulttext;
		Manager manager;

		private int health;
		public int hp;
		public string p_state;
		public int zint;
		private int score;
		private int highScore;
		private string highScoreKey = "highScore";
	
		void Start (){
				manager = GetComponent<Manager> ();
				zankit.text = "@5";
				Initialize ();
				p_state ="NORMAL";
				}
	
		void Update (){
				if (highScore < score) {
						highScore = score;
						}
				scoreGUIText.text = score.ToString ();
				highScoreGUIText.text = "HS:" + highScore.ToString ();
				playerstate.text = p_state;
				enemyHP.text = "BOSSHP:" + hp;
				zankit.text = "@" + zint;
				/*
				if(manager.clearb==true){

				}
				*/

				}

		private void Initialize (){
				score = 0;
				highScore = PlayerPrefs.GetInt (highScoreKey, 0);
				}

		public void AddPoint (int point){
				score = score + point;
				}

		public void Save (){
				PlayerPrefs.SetInt (highScoreKey, highScore);
				PlayerPrefs.Save ();
				Initialize ();
				}

		public void StateText(string state){
				p_state = state;
				}

		public void Hpchenge(int HP){
				hp = HP;
				}

		public void Zanki(int point){
				zint = point;
				Debug.Log("dead");
				}

		public void ResultScore(int point){
				score = score * point;
				FindObjectOfType<Resultscoreanime>().Scoreanimate(score);
				//resulttext.text=score +"pt";
		}
}