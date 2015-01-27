using UnityEngine;
using System.Collections;

public class LoadLevel : MonoBehaviour
{
		//public int level;
		string level = null;
		int levelIndex = 1;
		private bool firstTime = false;
		AndroidJavaClass jc;
		public bool loadAutomatic = false;
		// Use this for initialization
		void Start ()
		{
				if (!loadAutomatic) {
						jc = new AndroidJavaClass ("net.i2cat.empuriesar.UnityCommunication");
						if (jc != null) {
								//level = int.Parse (jc.GetStatic<string> ("androidLevel"));
								level = jc.GetStatic<string> ("androidLevel");
								SceneManager.idioma=jc.GetStatic<string>("idioma");
								Debug.Log ("Level to load:" + level+" idioma:"+SceneManager.idioma);
								//Application.LoadLevel (level);
						}
				} 
				InvokeRepeating ("SetFirstTime", 1f, 0f);
		
		
		}

		void Update ()
		{
				if (firstTime) {
						firstTime = false;
						if (level != null) {
								Debug.Log ("loading level:" + level);
								Application.LoadLevel (level);	
						} else {
								Application.LoadLevel (levelIndex);	
						}
				}
		}

		void SetFirstTime ()
		{
				firstTime = true;
		}
}