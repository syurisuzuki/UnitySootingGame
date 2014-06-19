using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour
{
		public GameObject[] waves;
		public GameObject EnemyHP;
		private int currentWave;
		private Manager manager;
	
	IEnumerator Start ()
	{
		if (waves.Length == 0) {
			yield break;
		}

			manager = FindObjectOfType<Manager>();
		
						while (true) {
						while(manager.IsPlaying() == false) {
							yield return new WaitForEndOfFrame ();
						}

						GameObject g = (GameObject)Instantiate (waves [currentWave], transform.position, Quaternion.identity);
			g.transform.parent = transform;
						while (g.transform.childCount != 0) {
								yield return new WaitForEndOfFrame ();
						}
						Destroy (g);

						if(waves.Length ==1){
							Instantiate (EnemyHP, transform.position, Quaternion.identity);
						}
						if (waves.Length <= ++currentWave) {
							currentWave = 0;
						}
			
						}
	}
		public void rest(){
				currentWave = 0;
		}
}