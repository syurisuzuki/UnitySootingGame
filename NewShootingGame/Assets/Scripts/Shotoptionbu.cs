using UnityEngine;
using System.Collections;

public class Shotoptionbu : MonoBehaviour {
		public GameObject OPbullet;
		public GameObject ffffffl;
		public int f;

		public void Shot (){
				Instantiate (OPbullet, transform.position, Quaternion.identity);
		}
}