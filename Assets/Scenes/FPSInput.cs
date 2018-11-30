using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]


public class FPSInput : MonoBehaviour {

	public float speed = 6.0f;
	public float gravity = -9.8f;
	
	private CharacterController  cc;

	void Start(){
		cc = this.GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update () {
		float deltaX = Input.GetAxis("Horizontal")*speed;
		float deltaZ = Input.GetAxis("Vertical")*speed;
		Vector3 movement = new Vector3(deltaX,0,deltaZ);
		movement = Vector3.ClampMagnitude(movement,speed);



		movement *=Time.deltaTime;
		movement = transform.TransformDirection(movement);
		movement.y += gravity*Time.deltaTime;
		cc.Move(movement);
	}
}
