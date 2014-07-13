using UnityEngine;
using System.Collections;

public class PlayerCover : MonoBehaviour {

	public bool inLowCover;
	public bool inHighCover;
	public int coverLevel = 1;
	public int coverState = 1;
	public int coverTotal = 0;

	private PlayerControl2 player;
	private GameObject highC;
	private GameObject lowC;

	void Awake()
	{
		player = GetComponent<PlayerControl2>();
		highC = GameObject.FindGameObjectWithTag ("HighCover");
		lowC = GameObject.FindGameObjectWithTag ("LowCover");
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		UpdateCoverLevel ();
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject == highC)
		{
			inHighCover = true;
			UpdateCover();
		}
		if(other.gameObject == lowC)
		{
			inLowCover = true;
			UpdateCover();
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if(other.gameObject == highC)
		{
			inHighCover = false;
			UpdateCover();
		}
		if(other.gameObject == lowC)
		{
			inLowCover = false;
			UpdateCover();
		}
	}
	
	//COVER
	void UpdateCover()
	{
		if (inHighCover) {
			coverState = 3;	
		} else if (inLowCover) {
			coverState = 2;	
		} else {
			coverState = 1;
		}
	}
	
	void UpdateCoverLevel()
	{
		coverTotal = coverLevel * (coverState + (player.sneak ? 1 : 0));
	}
}
