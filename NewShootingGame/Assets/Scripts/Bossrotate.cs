using UnityEngine;
using System.Collections;

public class Bossrotate : MonoBehaviour {
		public float speed = 0.005f;
	void Start () {
	
	}
	void Update () {
				transform.Translate(Vector3.up * -speed);
				transform.Rotate (0, 0, 0.5f);
	
	}
}
