using UnityEngine;
using System.Collections;

public class NewAutoaimBullet : MonoBehaviour {

		// 弾の移動スピード
		public int speed = 10;
		public int basespeed = 1;
		// ゲームオブジェクト生成から削除するまでの時間
		public float lifeTime = 1;
		// 攻撃力
		public int power = 1;
		public int basepower = 1;



		void Start ()
		{
				// ローカル座標のY軸方向に移動する
				rigidbody2D.velocity = transform.up.normalized * speed;

				// lifeTime秒後に削除
				Destroy (gameObject, lifeTime);
		}
				

		void Update(){

				transform.position += transform.forward * speed;

		}


		/*
		public Transform player;
		public Transform target;
		public Vector3 enemy;
		// 弾の移動スピード
		public int speed = 1;
		public int basespeed = 1;
		// ゲームオブジェクト生成から削除するまでの時間
		public float lifeTime = 1;
		// 攻撃力
		public int power = 1;
		public int basepower = 1;

		private float aimspeed = 0.1f;
		void Start ()
		{
				rigidbody.velocity = transform.up.normalized * speed;
				Destroy (gameObject, lifeTime);
		}
		void Update(){
				target = GameObject.Find("Enemy").transform;

				transform.position += transform.forward * speed;

		}

		public void aimbullet(){
				Vector3 targetPos = target.transform.position;
				targetPos.y = transform.position.y;
				targetPos.x = transform.position.x;
				//targetPos.z = transform.position.z;
				transform.LookAt(targetPos);
		}*/
}
