using UnityEngine;

public class Bullet : MonoBehaviour
{
		public int speed;
		public int basespeed;
		
		public float lifeTime;

		public int power;
		public int basepower;
		public bool autoaim;
		private Transform target;
		private Vector3 vec;
		private float speedaim = 0.06f;
		public bool option;

	void Start ()
	{
		rigidbody2D.velocity = transform.up.normalized * speed;
		Destroy (gameObject, lifeTime);
	}

		void Update(){
		
				if(autoaim==true){
						target = GameObject.Find ("Player(Clone)").transform;
						transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(target.position - transform.position), 0.9f);
						transform.position += transform.right * -speedaim;
				}else if(option==true){
						transform.position += transform.forward * speed;
				}else{
						transform.position += transform.forward * speed;
				}
		}
}