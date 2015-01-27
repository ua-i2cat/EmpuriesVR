using UnityEngine;
using System.Collections;

public class ButtonLoadScene : MonoBehaviour {

	public int level;
	
	public void OnClick ()
	{
		if (level >= 0) {
			Application.LoadLevel (level);
		} else {
			if (level == -1) {

				Application.Quit ();		
			} 
		}
	}
}
