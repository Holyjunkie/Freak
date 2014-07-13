using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour
{
	public float dampTime = 0.15f;
	public PlayerControl playerControl;
	private float mouseOffsetDistance = 3f;

	void Update()
	{
		if (playerControl)
		{
			Vector3 point = camera.WorldToViewportPoint(playerControl.transform.position);
			Vector3 delta = playerControl.transform.position - camera.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, point.z));
			Vector3 destination = transform.position + delta;
			transform.position = Vector3.Lerp(transform.position, destination + playerControl.cameraMouseOffset * mouseOffsetDistance, dampTime);
		}
	}
}
