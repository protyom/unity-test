using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxPhysics : MonoBehaviour {

	public float GRAVITY = -9.8f;

	private float speed = .0f;
	private float gravity = .0f;


	//private float startTime = .0f;
	private CharacterController cc;

	// Use this for initialization
	void Start () {
		cc = this.GetComponent<CharacterController>();
	}
	
	public void getHit(){
		if(speed <0.01f){
			gravity = GRAVITY;
			speed = 0.0f;
		}
	}



	// Update is called once per frame
	void Update () {
		speed += gravity * Time.deltaTime;
		Vector3 movement = new Vector3(0,speed,0);
		cc.Move(movement);
		if(cc.collisionFlags != CollisionFlags.None){
			gravity = 0.0f;
			speed = 0.0f;
		}
	}
}
