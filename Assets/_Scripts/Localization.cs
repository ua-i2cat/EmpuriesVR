using UnityEngine;
using System.Collections;

[RequireComponent (typeof(dfButton))]
public class Localization : MonoBehaviour
{
		public string catalan;
		public string spanish;
		public string english;
		// Use this for initialization
		void Start ()
		{
				dfButton mButton = GetComponent<dfButton> ();
				if (SceneManager.idioma.Equals ("spanish")) {
						mButton.Text = spanish;
				} else if (SceneManager.idioma.Equals ("catalan")) {
						mButton.Text = catalan;
				} else {
						mButton.Text = english;		
				}
		}
	

}
