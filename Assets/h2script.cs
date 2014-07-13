using UnityEngine;
using System.Collections;

public class h2script : MonoBehaviour {

	private GameObject player;

	// Use this for initialization
	void Start () {
	
	}

	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider other)
	{
		if (other.gameObject == player) {
			Debug.Log ("Works");
		}
	}

	void EnRayTest()
	{
		Vector2 origin = new Vector2 (transform.position.x, transform.position.y);
		Vector2 direction = new Vector2 (0, -1);
		Debug.DrawRay (origin, direction, Color.blue);
	}
}
