using UnityEngine;
using System.Collections;

public class Nguitest : MonoBehaviour {

		UISlider Slider;

	// Use this for initialization
	void Start () {
	

				//Slider = GameObject.Find ("Slider").GetComponent ();
				//Slider = GameObject.Find("Slider").GetComponent (UISlider);

	}
	
	// Update is called once per frame
	void Update () {
	
	}
		/*
		void OnGUI(){
				if (GUI.Button(new Rect(30,65, 60, 30), "Restart"))
				{
						Slider.value = 0.5f;
				}



		}
		*/

		/*public void MyButtonClick2() {
				GameObject progressBar = GameObject.Find("Slider") as GameObject;
				if (progressBar != null) {
						UISlider slider = progressBar.GetComponent("UISlider") as UISlider;
						if (slider != null) {
								slider.value += 0.1f;
								slider.value = Mathf.Min(slider.value, 1.0f);
						}
				}
		}
		*/

}
