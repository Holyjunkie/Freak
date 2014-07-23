using UnityEngine;
using System.Collections;

public class Enemy : Characters
{
	public bool playerInSight;
	public bool playerInSight2;
	public Vector2 playerLastSighting;

	private float s1Angle = (70f * Mathf.PI) / 180;
	private float s2Angle = (150f * Mathf.PI) / 180;

	public float s2Timer;
	public float h2Timer;
	public float smTimer;
	float timerDet = 60f;
	float timerReset = 0f;

	float dirX;
	float dirY;
	float radians;
	float rotateZ;
	float testAngleZ;
	float turnSmoothing = 5f;

	public bool pas;
	public bool sus;
	public bool ale;

	float susTimer;
	float susReset = 0f;
	float susTop = 30f;

	float aleTimer;
	float aleReset = 0f;
	float aleTop = 30f;

	public float speed = 2f;

	private PlayerControl playerCon;
	private PlayerCover2D playerCov;
	private GameObject player;
	private CircleCollider2D col;

	void Awake()
	{
		playerCon = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerControl> ();
		playerCov = GameObject.FindGameObjectWithTag ("Player").GetComponent<PlayerCover2D>();
		player = GameObject.FindGameObjectWithTag("Player");
		col = GetComponent<CircleCollider2D>();
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject == player) {
			DetectPlayer ();
			if(sus == true)
			{
				//target.transform.position = player.transform.position;
				//run pathfinding;
			}
		}
		//if(other.gameObject == noise) { }then set navmesh target to the position of the noise-maker.
	}

	void Update()
	{
		if (ale == true) {
			aleTimer = aleTop;
		}
		if (sus == true) {
			susTimer = susTop;
		}
		if (ale == true && sus == true && playerInSight == true) {
			susTimer = susTop;
			aleTimer = aleTop;
		}
		if (ale == true && sus == true && playerInSight != true) {
			aleTimer = aleTimer -= 1 * Time.time;
			Debug.Log (aleTimer);
			if(aleTimer <= aleReset){
				ale = false;
				aleTimer = aleReset;
				susTimer = susTimer -= 1 * Time.time;
				Debug.Log (susTimer);
				if(susTimer == susReset){
					sus = false;
					susTimer = susReset;
				}
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		ResetDetTimers ();
	}

	void DetectPlayer()
	{
		float d = Vector2.Distance (player.transform.position, this.transform.position);
		playerInSight = false;
		playerInSight2 = false;

		Vector2 origin = new Vector2 (this.transform.position.x, this.transform.position.y);
		Vector2 direction = player.transform.position - this.transform.position;

		int playerLayer = 14;
		int wallLayer = 13;
		int wallMask = 1 << wallLayer;
		int playerMask = 1 << playerLayer;
		int combinedMask = wallMask | playerMask;

		float s = Mathf.Atan2 (direction.y, direction.x);
		float v = transform.eulerAngles.z * Mathf.PI / 180;

		float threesixty = Mathf.PI * 2;

		while (s > threesixty) {
			s -= threesixty;
		}
		while (s <= 0) {
			s += threesixty;
		}

		if (sus == true) {
			RotateTowards (player);	
		}

		if (s >= v + (-s1Angle / 2) && s <= v + (s1Angle / 2)) {
			Debug.DrawRay (origin, direction, Color.blue);
			RaycastHit2D hit = Physics2D.Raycast (origin, direction, col.radius, combinedMask);
			Debug.Log (hit.collider.gameObject);
			if (hit.collider != null && hit.collider.gameObject == player) {
				if (playerCov.coverTotal <= 2) {
					playerInSight = true;
					sus = true;
					ale = true;
				}
			}
		} else if (s >= v + (-s2Angle / 2) && s <= v + (s2Angle / 2)) {
			Debug.DrawRay(origin, direction, Color.red);
			RaycastHit2D hit2 = Physics2D.Raycast (origin, direction, col.radius, combinedMask);
			if(hit2.collider != null && hit2.collider.gameObject == player)
			{
				if(playerCov.coverTotal <= 2)
				{
					playerInSight2 = true;
					s2Timer++;
					if(s2Timer >= timerDet)
					{
						s2Timer = timerDet;
						sus = true;
					}
				}
			}
		}
		if (playerInSight2 != true && playerInSight != true) {
			s2Timer --;
			if(s2Timer <= timerReset)
			{
				s2Timer = timerReset;
			}
		}
		if (d <= 3) {
			smTimer ++;
			if(smTimer >= timerDet)
			{
				smTimer = timerDet;
				sus = true;
			}
		}
		if (d <= 7 && d >= 3) {
			smTimer = timerReset;
			if(playerCon.xVelocity > 4 | playerCon.xVelocity < -4 | playerCon.yVelocity > 4 | playerCon.yVelocity < -4)
			{
				sus = true;
			}
		}
		if (d > 7) {
			smTimer = timerReset;
			if(playerCon.xVelocity > 4 | playerCon.xVelocity < -4 | playerCon.yVelocity > 4 | playerCon.yVelocity < -4)
			{
				h2Timer ++;
				if(h2Timer >= timerDet)
				{
					h2Timer = timerDet;
					sus = true;
				}
			} else if(playerCon.xVelocity < 4 | playerCon.xVelocity > -4 | playerCon.yVelocity < 4 | playerCon.yVelocity > -4)
			{
				h2Timer --;
				if(h2Timer <= timerReset)
				{
					h2Timer = timerReset;
				}
			}
		}
	}

	void ResetDetTimers()
	{
		playerInSight = false;
		playerInSight2 = false;
		h2Timer = timerReset;
		s2Timer = timerReset;
		smTimer = timerReset;
	}

	void RotateTowards(GameObject position)
	{
		{
			dirX = player.transform.position.x - transform.position.x;
			dirY = player.transform.position.y - transform.position.y;
			radians = Mathf.Atan2(dirY, dirX);
			testAngleZ = radians * 180 / Mathf.PI;
			rotateZ = Mathf.LerpAngle (transform.rotation.z, testAngleZ, turnSmoothing * Time.time);
			Vector3 facingPlayer = new Vector3 (this.transform.rotation.x, this.transform.rotation.y, rotateZ);

			transform.eulerAngles = facingPlayer;
		}
	}
}