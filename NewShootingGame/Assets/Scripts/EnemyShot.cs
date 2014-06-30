﻿using UnityEngine;
using System.Collections;

public class EnemyShot : MonoBehaviour {

		private float luncher = 3;
		public int Zint = 0;
		public float mat = 3.5f;
		public float startTime = 5.0f;
		public float timer;
		public bool paused = true;

		void Start () {
			reset();
			luncher = Random.Range (1, 10);
			transform.Rotate (new Vector3 (0,0,luncher*Random.Range(2,36)));
		}

		void Update () {
			transform.Rotate (0, 0,Zint);
			if (paused) return;
			timer -= Time.deltaTime;
			if (timer <= 0.0f){
				reset ();
			}

		}
		private void reset(){
			transform.Rotate (0, 0, 100);
			timer = startTime;
		}
}

