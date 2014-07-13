using UnityEngine;
using System.Collections;

public class TestRayRotation2 : MonoBehaviour {

	void Update () {
		RayTest ();
		RayTestTwo ();
	}
	
	void RayTest()
	{
		Vector3 origin = new Vector3 (transform.position.x, transform.position.y, transform.position.z);
		Vector3 direction = new Vector3 (Input.mousePosition.x - (Screen.width / 2), 0, Input.mousePosition.z - (Screen.height / 2));
		Debug.DrawRay (origin, direction, Color.blue);
	}
	
	void RayTestTwo()
	{
		Vector3 RotateTest = new Vector3 (0, 0, 20);
		transform.Rotate (RotateTest * Time.deltaTime, Space.Self);
	}
}
