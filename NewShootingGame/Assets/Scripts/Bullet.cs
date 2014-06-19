using UnityEngine;

public class Bullet : MonoBehaviour
{
	// 弾の移動スピード
	public int speed;
		public int basespeed;
	// ゲームオブジェクト生成から削除するまでの時間
	public float lifeTime;
	// 攻撃力
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