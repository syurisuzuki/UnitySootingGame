using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour
{

		/*oidhowethosfhp*/
		public GameObject[] waves;
		public GameObject EnemyHP;
		private int currentWave;
		private Manager manager;

		private GameObject player;

	
	IEnumerator Start ()
	{
		if (waves.Length == 0) {
			yield break;
		}

			manager = FindObjectOfType<Manager>();
		
				while (true) {
						while (manager.IsPlaying () == false) {
								yield return new WaitForEndOfFrame ();
						}
						GameObject g = (GameObject)Instantiate (waves [currentWave], transform.position, Quaternion.identity);
						g.transform.parent = transform;
						while (g.transform.childCount != 0) {
								yield return new WaitForEndOfFrame ();
						}
						Destroy (g);
						if (waves.Length < ++currentWave) {
								currentWave = 0;
						}else if(waves.Length == ++currentWave){
								FindObjectOfType<Manager>().GameClear();
								currentWave = 0;
								player = GameObject.Find ("Player(Clone)");
								Destroy (player);
								while (manager.ClearGame() == true) {
										yield return new WaitForEndOfFrame ();
								}
						}
				}
	}
		public void rest(){
				currentWave = 0;
		}
}