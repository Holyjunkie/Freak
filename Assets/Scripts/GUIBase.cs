using UnityEngine;
using System.Collections;

public class GUIBase : MonoBehaviour
{
	public Texture guiBaseTexture;
	
	public int guiWidth = 994;
	public int guiHeight = 141;
	
	public int guiMarginLeft = 0;
	public int guiMarginTop = 475;

	void OnGUI()
	{
		GUI.DrawTexture (new Rect (guiMarginLeft, guiMarginTop, guiWidth + guiMarginLeft, guiHeight), guiBaseTexture, ScaleMode.ScaleAndCrop, true, 0);
	}
}
