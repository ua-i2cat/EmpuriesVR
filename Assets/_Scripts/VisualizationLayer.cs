using UnityEngine;
 
using System.Collections.Generic;


public class VisualizationLayer :MonoBehaviour
{
		public int layerOrder = 1;
		public List<Transform> items=new List<Transform>();
		private bool isHidded = false;
		private dfCheckbox mCheck;
		private string nameIndex;
		void Awake(){
			nameIndex = gameObject.name.Substring (gameObject.name.Length - 1, 1);
			print ("Name:" + nameIndex);
			mCheck = GameObject.Find ("ChkLY" + nameIndex).GetComponent<dfCheckbox> ();
			mCheck.IsChecked = !isHidded;
		}
		public void SwapVisibility ()
		{
				print ("Swap visibility "+isHidded);
				if (isHidded) {
						ShowAll ();
						isHidded = false;
				} else {
						HiddeAll ();
						isHidded = true;
				}
		}

		public void HiddeAll ()
		{
				SetVisibile (false);
				isHidded = true;
				if (mCheck)
				mCheck.IsChecked = false;
		}

		private void ShowAll ()
		{
				SetVisibile (true);
				isHidded = false;
				if (mCheck)
				mCheck.IsChecked = true;
		}

		private void SetVisibile (bool visible)
		{
				int number = 0;
				for (int i=0; i<items.Count; i++) {
						Transform item = items [i];

						foreach (Transform child in item.gameObject.GetComponentsInChildren<Transform>(true)) {
								child.gameObject.SetActive (visible);
								number++;
						}
				}
				
		}
}
