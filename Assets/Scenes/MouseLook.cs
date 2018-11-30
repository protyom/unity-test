using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour {

	public const float MIN_ANGLE = -45.0f;
	public const float MAX_ANGLE = 45.0f;
	
	public enum RotationAxes{
		MouseXandY,
		MouseX,
		MouseY,
	}

	public RotationAxes axes  = RotationAxes.MouseXandY;
	public float sensivityHorizontal = 9.0f;
	public float sensivityVertical = 9.0f;

	private float rotationX=0.0f;
	private float rotationY=0.0f;


	void Start(){
		Rigidbody body = this.GetComponent<Rigidbody>();
		if(body!=null){
			body.freezeRotation = true;
		}
	}

	// Update is called once per frame
	void Update () {
		if(axes==RotationAxes.MouseXandY){
			rotationX -= Input.GetAxis("Mouse Y")*sensivityVertical;
			rotationX = Mathf.Clamp(rotationX,MIN_ANGLE,MAX_ANGLE);
			rotationY += Input.GetAxis("Mouse X")*sensivityHorizontal;
			transform.localEulerAngles = new Vector3(rotationX,rotationY,0);
			Debug.Log("("+rotationX+","+rotationY+")");
		}else if(axes==RotationAxes.MouseX){
			transform.Rotate(0,sensivityHorizontal*Input.GetAxis("Mouse X"),0);
		}else if(axes==RotationAxes.MouseY){
			rotationX -= Input.GetAxis("Mouse Y")*sensivityVertical;
			rotationX = Mathf.Clamp(rotationX,MIN_ANGLE,MAX_ANGLE);
			rotationY = transform.localEulerAngles.y;
			transform.localEulerAngles = new Vector3(rotationX,rotationY,0);
		}
	}
}
