using UnityEngine;
using System.Collections;
using System.Collections.Generic;
 
[AddComponentMenu("Camera-Control/Smooth Mouse Look")]
public class cameraLook : MonoBehaviour {
 
	public enum RotationAxes { MouseXAndY = 0, MouseX = 1, MouseY = 2 }
	public RotationAxes axes = RotationAxes.MouseXAndY;
	public float sensitivityX = 1;
	public float sensitivityY = 1;
 
	public float minimumX = -360F;
	public float maximumX = 360F;
 
	public float minimumY = -60F;
	public float maximumY = 60F;
 
	float rotationX = 0F;
	float rotationY = 0F;
 
	private List<float> rotArrayX = new List<float>();
	float rotAverageX = 0F;	
 
	private List<float> rotArrayY = new List<float>();
	float rotAverageY = 0F;
 
	public float frameCounter = 20;
 
	Quaternion originalRotation;

	
 
	void Update ()
	{
		if(Input.GetKey(KeyCode.W)){
			transform.Translate(Vector3.forward * (Time.deltaTime*3));
		}
		if(Input.GetKey(KeyCode.A)){
			transform.Translate(Vector3.left * (Time.deltaTime*3));
		}
		if(Input.GetKey(KeyCode.D)){
			transform.Translate(Vector3.right * (Time.deltaTime*3));
		}
		if(Input.GetKey(KeyCode.S)){
			transform.Translate(Vector3.back * (Time.deltaTime*3));
		}
		if(transform.position.y < 2){
			transform.position = new Vector3(transform.position.x, 2.0f, transform.position.z);
		}
		if (axes == RotationAxes.MouseXAndY)
		{			
			rotAverageY = 0f;
			rotAverageX = 0f;
 
			rotationY += Input.GetAxis("Mouse Y");
			rotationX += Input.GetAxis("Mouse X");
 
			rotArrayY.Add(rotationY);
			rotArrayX.Add(rotationX);
 
			if (rotArrayY.Count >= frameCounter) {
				rotArrayY.RemoveAt(0);
			}
			if (rotArrayX.Count >= frameCounter) {
				rotArrayX.RemoveAt(0);
			}
 
			for(int j = 0; j < rotArrayY.Count; j++) {
				rotAverageY += rotArrayY[j];
			}
			for(int i = 0; i < rotArrayX.Count; i++) {
				rotAverageX += rotArrayX[i];
			}
 
			rotAverageY /= rotArrayY.Count;
			rotAverageX /= rotArrayX.Count;
 
			rotAverageY = ClampAngle (rotAverageY, minimumY, maximumY);
			rotAverageX = ClampAngle (rotAverageX, minimumX, maximumX);
 
			Quaternion yQuaternion = Quaternion.AngleAxis (rotAverageY, Vector3.left);
			Quaternion xQuaternion = Quaternion.AngleAxis (rotAverageX, Vector3.up);
 
			transform.localRotation = originalRotation * xQuaternion * yQuaternion;
		}
		else if (axes == RotationAxes.MouseX)
		{			
			rotAverageX = 0f;
 
			rotationX += Input.GetAxis("Mouse X");
 
			rotArrayX.Add(rotationX);
 
			if (rotArrayX.Count >= frameCounter) {
				rotArrayX.RemoveAt(0);
			}
			for(int i = 0; i < rotArrayX.Count; i++) {
				rotAverageX += rotArrayX[i];
			}
			rotAverageX /= rotArrayX.Count;
 
			rotAverageX = ClampAngle (rotAverageX, minimumX, maximumX);
 
			Quaternion xQuaternion = Quaternion.AngleAxis (rotAverageX, Vector3.up);
			transform.localRotation = originalRotation * xQuaternion;			
		}
		else
		{			
			rotAverageY = 0f;
 
			rotationY += Input.GetAxis("Mouse Y");
 
			rotArrayY.Add(rotationY);
 
			if (rotArrayY.Count >= frameCounter) {
				rotArrayY.RemoveAt(0);
			}
			for(int j = 0; j < rotArrayY.Count; j++) {
				rotAverageY += rotArrayY[j];
			}
			rotAverageY /= rotArrayY.Count;
 
			rotAverageY = ClampAngle (rotAverageY, minimumY, maximumY);
 
			Quaternion yQuaternion = Quaternion.AngleAxis (rotAverageY, Vector3.left);
			transform.localRotation = originalRotation * yQuaternion;
		}
	}
 
	void Start ()
	{		
        Rigidbody rb = GetComponent<Rigidbody>();	
		if (rb)
			rb.freezeRotation = true;
		originalRotation = transform.localRotation;

		Cursor.visible = false;
	}
 
	public static float ClampAngle (float angle, float min, float max)
	{
		angle = angle % 360;
		if ((angle >= -360F) && (angle <= 360F)) {
			if (angle < -360F) {
				angle += 360F;
			}
			if (angle > 360F) {
				angle -= 360F;
			}			
		}
		return Mathf.Clamp (angle, min, max);
	}
}
