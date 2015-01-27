using UnityEngine;
using System.Collections;

public class MenuPause : MonoBehaviour
{
	
	public static bool menuOnPause = false;
	
	private Rect rect1, rect2, rect3, rect4, rect5,rect6;
	public GUISkin skin;
	public static float horizRatio;
	public static float vertRatio;
	void Awake ()
	{
		rect1 = new  Rect ((Screen.width - 100) * 0.5f, (Screen.height - 50) * 0.1f, 100f, 40f);
		rect2 = new  Rect ((Screen.width - 100) * 0.5f, (Screen.height - 50) * 0.2f, 100f, 40f);
		rect3 = new  Rect ((Screen.width - 100) * 0.5f, (Screen.height - 50) * 0.3f, 100f, 40f);
		rect4 = new  Rect ((Screen.width - 100) * 0.5f, (Screen.height - 50) * 0.4f, 100f, 40f);
		rect5 = new  Rect ((Screen.width - 100) * 0.5f, (Screen.height - 50) * 0.5f, 100f, 40f);
		rect6 = new  Rect ((Screen.width - 100) * 0.5f, (Screen.height - 50) * 0.6f, 100f, 40f);
		Screen.sleepTimeout = SleepTimeout.NeverSleep;
		horizRatio = Screen.width / 800F;
		
		vertRatio = Screen.height / 480F;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape) || Input.GetKeyDown (KeyCode.Menu)) {
			if (menuOnPause){
				menuOnPause=false;

				
			}else{
				menuOnPause = true;
				 
				
			}
		}
		
	}
	
	void OnGUI ()
	{
		
		
		//MENU  
		if (menuOnPause) {
			GUI.matrix=Matrix4x4.TRS(Vector3.zero,Quaternion.identity,new Vector3(horizRatio,vertRatio,1F));
			//GUI.skin=skin;
			//Time.timeScale = 0.1f;
			
			if (GUI.Button (rect2, "Reiniciar")) {
				
				menuOnPause = false;

				Application.LoadLevel(0);
				
			}	 
			
			if (GUI.Button (rect4, "Sortir")) {
				
				menuOnPause = false;

				Application.Quit();
				
			}	
			
		}
	}
}