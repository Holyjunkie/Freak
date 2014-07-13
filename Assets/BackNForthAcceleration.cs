using UnityEngine;
using System.Collections;

public class BackNForthAcceleration : MonoBehaviour {
	public float moveSpeed;
	private Vector3 moveDirection;
	public float turnSpeed;
	public float speedFactor;
	public bool gotIt; 
	
	
	
	// Use this for initialization
	void Start () {
		moveDirection = Vector3.right;
		gotIt = false;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 currentPosition = transform.position;

		if ((Input.GetButton ("Fire1")) && (currentPosition.x > -0.1 && currentPosition.x < 0.1))
		{
			gotIt = !gotIt;
		}


		
		if (currentPosition.x < -3.0)
		{
			moveDirection = Vector3.right;
		}
		else if (currentPosition.x > 3.0)
		{
			moveDirection = Vector3.left;
		}
		Vector3 target = moveDirection * moveSpeed + currentPosition;
		transform.position = Vector3.Lerp (currentPosition, target, Time.deltaTime);

//		if (currentPosition.x > -0.1 && currentPosition.x < 0.1 )
//		{
//			if(gotIt == false)
//			{
//			gotIt = true;
//			}
//			else 
//			{
//			gotIt = false;
//			}
//		}
		
	}
}