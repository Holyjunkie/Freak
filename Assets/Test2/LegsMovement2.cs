using UnityEngine;
using System.Collections;

public class LegsMovement2 : MonoBehaviour {

	public float playerTurnSmoothing = 15f;

	public void RotateWithVelocity (float x, float y)
	{
		Vector3 targetDirection = new Vector3 (0f, 90 + (Mathf.Atan2 (y, x) * 180 / Mathf.PI), 0f);
		Quaternion targetRotation = Quaternion.Euler (targetDirection);
		Quaternion newRotation = Quaternion.Lerp (transform.rotation, targetRotation, playerTurnSmoothing * Time.deltaTime);
		transform.rotation = newRotation;
	}
}
