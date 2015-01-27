using UnityEngine;
using System.Collections;

public class AndroidCommunication : MonoBehaviour {
	AndroidJavaClass ajc;
	// Use this for initialization
	void Awake () {
		ajc = new AndroidJavaClass ("net.i2cat.empuriesar.UnityCommunication");
		string mLevel = ajc.GetStatic<string> ("levelValue");
		Debug.Log("Level returned:"+mLevel);
		int level = int.Parse(mLevel);
		//Application.LoadLevel (level);
	}
	
	 
}
