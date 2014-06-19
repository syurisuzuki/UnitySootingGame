using UnityEngine;
using System.Collections;

public class Bossrotate : MonoBehaviour {
		public float speed = 0.005f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				transform.Translate(Vector3.up * -speed);
				transform.Rotate (0, 0, 0.5f);
	
	}
}
