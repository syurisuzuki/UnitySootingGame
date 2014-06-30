using UnityEngine;
using System.Collections;

public class Resultscoreanime : MonoBehaviour {

		public int animescore;
		public GUIText result;
		public bool animbool;

		public int maxscore;

		// Use this for initialization
		void Start () {
				result.text =""+animescore.ToString();
				Scoreanimate (maxscore);
			}
	
		// Update is called once per frame
		void Update () {
		
				/*animescore += 1;
				if(animescore>30000)
						{
						animescore = 0;
						}
								
				result.text = ""+animescore;*/
	
						}

		//数字がどんどん増えていくような表現にする予定
		public void Scoreanimate(int point)
		{
				for(int i = 0;i<point;i++)
				{
						animescore++;
						result.text = ""+animescore;
				}
		}


}
