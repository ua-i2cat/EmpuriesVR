using UnityEngine;
using System.Collections;
[RequireComponent (typeof (GUITexture))]
public class DpiPos : MonoBehaviour {
	float scaleFactorx=1.5f;
	float scaleFactory=1.5f;
	public float originalWidth=771f;
	public float originalHeight=578f;
	void Awake() {

		scaleFactorx=Screen.width/originalWidth;
		scaleFactory = Screen.height / originalHeight;
		//print ("ScaleFactor  "+scaleFactor);

		
		//guiTexture.pixelInset=ScreenUtils.DpToPixel(guiTexture.pixelInset);
		Rect actual=guiTexture.pixelInset;
		Rect newRect=new Rect(actual.x*scaleFactorx,actual.y*scaleFactory,actual.width*scaleFactorx,actual.height*scaleFactory);
		guiTexture.pixelInset=newRect;
		 
		 
	}
}
