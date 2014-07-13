using UnityEngine;
using System.Collections;

public class LastKnownPosition : MonoBehaviour {

	Vector2 position = new Vector2 (5000, -5000);
	Vector2 resetPosition = new Vector2 (5000, -5000);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	//	LastKnownPosTest ();
	}

	void LastKnownPosTest()
	{
		if (position != resetPosition) {

		} else if(position == resetPosition) {

		}
	}
}
