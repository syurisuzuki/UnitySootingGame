using UnityEngine;
using System.Collections;

public class Textsample : MonoBehaviour {

		public GUIText extext;
		public GUIText clear;
		private string[] textarray;

	// Use this for initialization
	void Start () {
				extext.text ="key operation\n\nF   shot type\nchenge \nQ  option shot \n type chenge \n";
				clear.text ="Congratulations\n\nPressX";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
