using UnityEngine;
using System.Collections;

public class GUIZedVision : MonoBehaviour
{
	public Texture zombieVision;

	public int zVisMarginLeft = 10;
	public int zVisMarginTop = 10;

	public int zVisWidth = 20;
	public int zVisHeight = 20;

	public bool zedVision;

	void ZedVision()
	{
		GUI.DrawTexture (new Rect (zVisMarginLeft, zVisMarginTop, zVisMarginLeft + zVisWidth, zVisMarginTop + zVisHeight), zombieVision, ScaleMode.ScaleAndCrop, true, 0);
		if (Input.GetButton ("Zed Vision"))
		{
			zedVision = !zedVision;
			if(zedVision)
			{

			}
		}
	}
}
