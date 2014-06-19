using UnityEngine;
using System.Collections;

public class Shotoption : MonoBehaviour {

		public enum OptionState{
				OPTION_NORMAL,
				OPTION_RAPID,
				OPTION_HEAVY,
				OPTION_EXTEND,
				OPTION_FINAL
		}

		private OptionState state;
		public GameObject OPbullet;
		public GameObject OPbullet2;
		public GameObject OPbullet3;
		public GameObject OPbullet4;
		public GameObject OPbullet5;
		private int optionLV;

		void Start (){
				state = OptionState.OPTION_NORMAL;
				optionLV = 0;
				}

		void Update(){
				if(Input.GetKeyDown("q")){
						switch(state){
						case OptionState.OPTION_NORMAL:
								//Debug.Log ("normal shot");
								state = OptionState.OPTION_RAPID;
								break;
						case OptionState.OPTION_HEAVY:
								state = OptionState.OPTION_RAPID;
								break;
						case OptionState.OPTION_RAPID:
								state = OptionState.OPTION_EXTEND;
								break;
						case OptionState.OPTION_EXTEND:
								state = OptionState.OPTION_FINAL;
								break;
						case OptionState.OPTION_FINAL:
								state = OptionState.OPTION_NORMAL;
								break;
						}
				}
		}

		public void Shot (){
				switch(state){
				case OptionState.OPTION_NORMAL:
						Debug.Log ("normal shot");
						Instantiate (OPbullet, transform.position, Quaternion.identity);
						break;
				case OptionState.OPTION_HEAVY:
						Instantiate (OPbullet2, transform.position, Quaternion.identity);
						Debug.Log ("heavy shot");
						break;
				case OptionState.OPTION_RAPID:
						Instantiate (OPbullet3, transform.position, Quaternion.identity);
						Debug.Log ("rapid shot");
						break;
				case OptionState.OPTION_EXTEND:
						Instantiate (OPbullet4, transform.position, Quaternion.identity);
						Debug.Log ("extend shot");
						break;
				case OptionState.OPTION_FINAL:
						Instantiate (OPbullet5, transform.position, Quaternion.identity);
						Debug.Log ("finel shot");
						break;
				}
		}



		public void ShotChenge(int lv){
				optionLV += lv;
				switch(optionLV){
				case 1:
						state = OptionState.OPTION_NORMAL;
						break;
				case 2:
						state = OptionState.OPTION_HEAVY;
						break;
				case 3:
						state = OptionState.OPTION_RAPID;
						break;
				case 4:
						state = OptionState.OPTION_EXTEND;
						break;
				case 5:
						state = OptionState.OPTION_FINAL;
						break;
				default:
						Debug.Log ("over option LV!!");
						break;
				}
		}
}