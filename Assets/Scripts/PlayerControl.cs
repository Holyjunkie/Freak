using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour 
{
	private float maxVelocity = 5f;
	public float xVelocity;
	public float yVelocity;
	public bool sprint;
	public bool sneak;
	public bool zedVis;

	public bool playerDet;
	public bool playerSus;

	public Vector3 cameraMouseOffset;

	public TinkerTorsoRotation torso;
	public LegsMovement legs;

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
		this.transform.Translate(new Vector3(xVelocity, yVelocity, 0) * Time.deltaTime);

		Vector3 mouseScreen = Input.mousePosition;
		Vector3 mouseScreenPosition = new Vector3( mouseScreen.x, mouseScreen.y, -Camera.main.transform.position.z );
		Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint( mouseScreenPosition );

		mouseWorldPosition = transform.worldToLocalMatrix.MultiplyPoint (mouseWorldPosition);

		cameraMouseOffset = new Vector3 (
			((mouseScreenPosition.x / Screen.width) * 2) - 1, 
			((mouseScreenPosition.y / Screen.height) * 2) - 1, 
			0
		);
		
		torso.transform.rotation = Quaternion.Euler (0, 0, (Mathf.Atan2 (mouseWorldPosition.y, mouseWorldPosition.x) * 180 / Mathf.PI) - 90);

		if (xVelocity != 0 | yVelocity != 0)
		{
			legs.RotateWithVelocity (xVelocity, yVelocity);
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
