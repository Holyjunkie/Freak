using UnityEngine;
using System.Collections;

public class HealthBarScript : MonoBehaviour
{
	public Texture backgroundTexture;
	public Texture foregroundTexture;
	public Texture frameTexture;

	public int healthWidth = 165;
	public int healthHeight = 27;

	public int healthMarginLeft = 54;
	public int healthMarginTop = 529;

	public int frameWidth = 167;
	public int frameHeight = 1054;

	public int frameMarginLeft = 53;
	public int frameMarginTop = 10;

	void OnGUI()
	{
		GUI.DrawTexture (new Rect (frameMarginLeft, frameMarginTop, frameMarginLeft + frameWidth, frameMarginTop + frameHeight), backgroundTexture, ScaleMode.ScaleToFit, true, 0);
		GUI.DrawTexture (new Rect (healthMarginLeft, healthMarginTop, healthWidth + healthMarginLeft, healthHeight), foregroundTexture, ScaleMode.ScaleAndCrop, true, 0);
		GUI.DrawTexture (new Rect (frameMarginLeft, frameMarginTop, frameMarginLeft + frameWidth, frameMarginTop + frameHeight), frameTexture, ScaleMode.ScaleToFit, true, 0);
	}
}
