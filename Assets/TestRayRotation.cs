using UnityEngine;
using System.Collections;

public class TestRayRotation : MonoBehaviour {



	void Update () {
		RayTest ();
		RayTestTwo ();
	}

	void RayTest()
	{
		Vector2 origin = new Vector2 (transform.position.x, transform.position.y);
		Vector2 direction = new Vector2 (Input.mousePosition.x - (Screen.width / 2), Input.mousePosition.y - (Screen.height / 2));
		Debug.DrawRay (origin, direction, Color.blue);
	}

	void RayTestTwo()
	{
		Vector3 RotateTest = new Vector3 (0, 0, 20);
		transform.Rotate (RotateTest * Time.deltaTime, Space.Self);
	}

	/*
	 * use the rotation of the object. */
}
