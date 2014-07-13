using UnityEngine;
using System.Collections;

public class PlayerControl2 : MonoBehaviour {

	private float maxVelocity = 5f;
	public float xVelocity;
	public float yVelocity;
	public bool sprint;
	public bool sneak;
	public bool zedVis;

	public Vector3 cameraMouseOffset;
	
	public TinkerTorsoRotation torso;
	public LegsMovement2 legs;
	
	void Start()
	{
		
	}
	
	void Awake()
	{
		
	}
	
	void Update () 
	{
		PlayerGeneralMovement ();
	}
	
	//GENERAL MOVEMENT
	
	void PlayerGeneralMovement()
	{
		// MOVEMENT
		
		yVelocity = Input.GetAxis ("Vertical") * maxVelocity;
		xVelocity = Input.GetAxis ("Horizontal") * maxVelocity;
		this.transform.Translate(new Vector3(xVelocity, yVelocity, 0f) * Time.deltaTime);
		
		Vector3 mouseScreen = Input.mousePosition;
		Vector3 mouseScreenPosition = new Vector3( mouseScreen.x, mouseScreen.y, Camera.main.transform.position.y - 5 );
		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint( mouseScreenPosition );

		mouseWorldPosition = transform.worldToLocalMatrix.MultiplyPoint (mouseWorldPosition);

		/*
		cameraMouseOffset = new Vector3 (
			((mouseScreenPosition.x / Screen.width) * 2) - 1,
			0,  
			((mouseScreenPosition.y / Screen.height) * 2) - 1
			);
		*/

		float angle = -(Mathf.Atan2 (mouseWorldPosition.y, mouseWorldPosition.x) * 180 / Mathf.PI);
		torso.transform.rotation = Quaternion.Euler (0, angle, 0);

		if (xVelocity != 0 | yVelocity != 0)
		{
			legs.RotateWithVelocity (xVelocity, -yVelocity);
		}
		// SPRINTING
		
		if (Input.GetButtonDown ("Sprint"))
		{
			sprint = !sprint;
			if (sprint)
			{
				if(sneak == true)
				{
					sneak = false;
					maxVelocity *= 3;
				}
				maxVelocity *= 2;
			}
			else
			{
				maxVelocity /= 2;
			}
		}
		
		// SNEAKING
		
		if (Input.GetButtonDown ("Sneak"))
		{
			sneak = !sneak;
			if (sneak)
			{
				if(sprint == true)
				{
					sprint = false;
					maxVelocity /= 2;
				}
				maxVelocity /= 3;
			}
			else
			{
				maxVelocity *= 3;
			}
		}
		
		// ZED VISION
		
		if (Input.GetButtonDown ("Zed Vision"))
		{
			zedVis = !zedVis;
			if(zedVis == true)
			{
				
			}
		}
	}
}