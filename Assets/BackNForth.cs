using UnityEngine;
using System.Collections;

public class BackNForth : MonoBehaviour {
	public float moveSpeed;
	private Vector3 moveDirection;
	public float turnSpeed;
	public float framesPerSecond;
	
	
	
	// Use this for initialization
	void Start () {
		moveDirection = Vector3.up;
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % 2;

		if (index == 0)
		{
			moveDirection = Vector3.right;
		}
		else
		{
			moveDirection = Vector3.left;
		}
		Vector3 target = moveDirection * moveSpeed + currentPosition;
		transform.position = Vector3.Lerp (currentPosition, target, Time.deltaTime);

	}
}