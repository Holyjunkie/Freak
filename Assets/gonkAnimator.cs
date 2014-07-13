using UnityEngine;
using System.Collections;

public class gonkAnimator : MonoBehaviour {

	public Sprite[] gonks;
	public float framesPerSecond;

	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		spriteRenderer = renderer as SpriteRenderer;
	}
	
	// Update is called once per frame
	void Update () {
	
		int index = (int)(Time.timeSinceLevelLoad * framesPerSecond);
		index = index % gonks.Length;
		spriteRenderer.sprite = gonks [index];
	}
}
