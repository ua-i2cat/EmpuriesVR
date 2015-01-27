using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SceneManager : MonoBehaviour {
	private Light mLight;
	public static string idioma="english";
	public List<VisualizationLayer> initialHiddedLayers; 
	// Use this for initialization
	void Start () {
		mLight = GameObject.FindObjectOfType<Light> ();
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		foreach (VisualizationLayer layer in initialHiddedLayers) {
			layer.HiddeAll();		
		}
	}
	void Update(){
		if (Input.GetKeyDown (KeyCode.Escape)) {
			//Application.LoadLevel(0);
			//Application.Quit();
			BackButtonTreatment();
		}
	}
	 
	public void SwapShadows(){
		print ("Swaping shadows");
		if (mLight) {
			if (mLight.shadows!=LightShadows.None){
				mLight.shadows=LightShadows.None;
			}else{
				mLight.shadows=LightShadows.Hard;
			}
				
		}
	}
	public void BackButtonTreatment(){
		Debug.Log ("From Unity quiting activity");
		AndroidJavaClass jc = new AndroidJavaClass ("com.unity3d.player.UnityPlayer"); 
		AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject> ("currentActivity"); 
		jo.Call ("stopActivity");
	}
	 
}
