using UnityEngine;
using System.Collections;
[RequireComponent (typeof (GUITexture))]
public class DpiPos_old : MonoBehaviour {
	float scaleFactor=1.5f;
	public float originalWidth=800f;
	 
	void Awake() {

		scaleFactor=Screen.width/originalWidth;
		//print ("ScaleFactor  "+scaleFactor);

		
		//guiTexture.pixelInset=ScreenUtils.DpToPixel(guiTexture.pixelInset);
		Rect actual=guiTexture.pixelInset;
		Rect newRect=new Rect(actual.x*scaleFactor,actual.y*scaleFactor,actual.width*scaleFactor,actual.height*scaleFactor);
		guiTexture.pixelInset=newRect;
		 
		 
	}
}
