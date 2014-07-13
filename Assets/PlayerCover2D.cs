using UnityEngine;
using System.Collections;

public class PlayerCover2D : MonoBehaviour {

	public bool inLowCover;
	public bool inHighCover;
	public int coverLevel = 1;
	public int coverState = 1;
	public int coverTotal = 0;
	
	private PlayerControl player;
	
	void Awake()
	{
		player = GetComponent<PlayerControl>();
	}
	
	void Start () {
		
	}
	
	void Update () {
		UpdateCoverLevel ();
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if(other.gameObject.tag == "HighCover")
		{
			inHighCover = true;
			UpdateCover();
		}
		if(other.collider2D.tag == "LowCover")
		{
			inLowCover = true;
			UpdateCover();
		}
	}
	
	void OnTriggerExit2D(Collider2D other)
	{
		if(other.gameObject.tag == "HighCover")
		{
			inHighCover = false;
			UpdateCover();
		}
		if(other.gameObject.tag == "LowCover")
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
