using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myCameraLook : MonoBehaviour
{
	Vector3 initialMouse;
	Vector3 nextMouse;
	float addX;
	float addY;
	//float ZCONST = 0f;

	public float minimumX = -360F;
	public float maximumX = 360F;
 
	public float minimumY = -60F;
	public float maximumY = 60F;

	Quaternion originalRotation;
    // Start is called before the first frame update
    void Start()
    {
    	initialMouse = new Vector3(0f, 0f, 0f);
        nextMouse = Input.mousePosition;
        originalRotation = transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
    	//Debug.Log("z: " + gameObject.transform.rotation.z);
        nextMouse = Input.mousePosition;
    	//transform.LookAt(Input.mousePosition);
    	if(initialMouse != nextMouse) {
    		//nextMouse = Input.mousePosition;
    		addX = initialMouse.x - nextMouse.x;
    		addY = initialMouse.y- nextMouse.y;
    		Debug.Log("x: " + addX + ", y: " + addY);

    		addY =  Mathf.Clamp(addY, minimumY, maximumY);
			addX =  Mathf.Clamp(addX, minimumX, maximumX);

			Quaternion yQuaternion = Quaternion.AngleAxis (addX, Vector3.left);
			Quaternion xQuaternion = Quaternion.AngleAxis (addY, Vector3.up);

    		//gameObject.transform.Rotate(addY, -addX, ZCONST, Space.Self);
    		transform.localRotation = originalRotation * xQuaternion * yQuaternion;
    		originalRotation = transform.localRotation;
    		initialMouse = nextMouse;
    	}

    	//Debug.Log(initialMouse);
    }
}
