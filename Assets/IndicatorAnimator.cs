using UnityEngine;
using System.Collections;

public class IndicatorAnimator : MonoBehaviour {
	public Sprite[] Indicator;
	public float framesPerSecond;
	
	private SpriteRenderer spriteRenderer;


	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
		int index = 0;
		GameObject BonkObject = GameObject.Find("Bonk"); 
		BackNForthAcceleration component = (BackNForthAcceleration) BonkObject.GetComponent(typeof(BackNForthAcceleration));
		if (component.gotIt)
		{
			index = 0;
			spriteRenderer.sprite = Indicator [index];
		} 
		else 
		{
			index = 1;
			spriteRenderer.sprite = Indicator [index];
		}
	}
}
