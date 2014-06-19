using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
public class Spaceship : MonoBehaviour
{

		public float speed;
		public float basespeed = 0.5f;
		public float shotDelay;
		public float baseshotDelay = 0.5f;
		public GameObject bullet;
		public bool canShot;
		public GameObject explosion;
		public GameObject getanim;
		private Animator animator;
		private GameObject player;

		void Start (){
				animator = GetComponent<Animator> ();
				player = GameObject.Find ("Player");
				}

		public void Explosion (){
				Instantiate (explosion, transform.position, transform.rotation);
				}

		public void Shot (Transform origin){
				Instantiate (bullet, origin.position, origin.rotation);
				}

		public Animator GetAnimator(){
				return animator;
				}

		public void Getitem(){
				Instantiate (getanim, transform.position, transform.rotation);
				player.transform.parent = getanim.transform;
		}

}