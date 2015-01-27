using UnityEditor;
using UnityEngine;
using System.Collections.Generic;
public class I2CatOptions : MonoBehaviour
{

		private static int layerVisible = 8;
		private static int layerInvisible = 9;
		private static int numberOfVisibles;
		private static int numberOfInvisibles;
		static RaycastHit hit;

		[MenuItem ("I2CAT/FindIfVisible")]
		static void FindIfVisible ()
		{
				numberOfVisibles = 0;
				numberOfInvisibles = 0;
				GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject> ();
				for (int i=0; i<allObjects.Length-1; i++) {
						GameObject go = allObjects [i];
						if (go.renderer == null)
								continue;
						if (go.renderer.isVisible) {
								if (HitsCamera (go.transform)) {
										go.layer = layerVisible;
										numberOfVisibles++;
								} else {
										go.layer = layerInvisible;
										numberOfInvisibles++;
								}

						} else {
								go.layer = layerInvisible;
								numberOfInvisibles++;
						}
				}
				print ("Visibles:" + numberOfVisibles + " invisibles:" + numberOfInvisibles);
		}
	[MenuItem ("I2CAT/DeleteWithoutMesh")]
	static void DeleteWithoutMesh ()
	{
		int numberOfDeleted = 0;
		 
		GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject> ();
		for (int i=0; i<allObjects.Length-1; i++) {
			GameObject go = allObjects [i];
			Component[] components=go.GetComponents<Component>();
			 
			if (go.transform.childCount== 0 && components.Length==1){
				print ("To delete:" + go.name );
				Object.DestroyImmediate (go,false);
				numberOfDeleted++;
			}
		}
		print ("Total deleted:" + numberOfDeleted);

	}
	[MenuItem ("I2CAT/PutInLayers")]
	static void PutInLayers ()
	{

		int numberOfLayers = 0;
		List<VisualizationLayer> layers = new List<VisualizationLayer> ();
		List<string> nameLayers=new List<string>();
		GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject> ();
		for (int i=0; i<allObjects.Length-1; i++) {
			GameObject go = allObjects [i];
			string indexname=go.name.Substring(0,4);

			if (go.name.StartsWith("ly_") ){
				VisualizationLayer currentLayer=null;
			if ( !nameLayers.Contains(indexname)){

				nameLayers.Add(indexname);
				Debug.Log("new layer "+indexname);
				GameObject newGameObject=new GameObject("Layer"+indexname);
				newGameObject.transform.position=new Vector3(0,0,0);
				newGameObject.AddComponent("VisualizationLayer");
				currentLayer=newGameObject.GetComponent<VisualizationLayer>();
				layers.Add(currentLayer);

			}else{
					currentLayer=layers[nameLayers.IndexOf(indexname)];
			}
				currentLayer.items.Add(go.transform);
			}

		}
		print ("Total layers:" + nameLayers.Count);
		
	}
		void NORES ()
		{
				GameObject[] allObjects = GameObject.FindObjectsOfType<GameObject> ();
				for (int i=0; i<allObjects.Length-1; i++) {
					GameObject go=allObjects[i];
						if(go.renderer==null) continue;
						//Transform mTransform = allObjects [i].transform;
						//Vector3 position=mTransform.position;
						Vector3 position = go.renderer.bounds.center;
						//Debug.DrawRay (position, (Camera.main.transform.position - position));
						if (Physics.Raycast (position, (Camera.main.transform.position - position), out hit)) {
								if (hit.transform == Camera.main.transform) {
									Debug.DrawRay (position, (Camera.main.transform.position -position));
								}else{
									go.SetActive(false);
								}

						}
				}
				
		}

		private static bool HitsCamera (Transform mTransform)
		{
	
				Debug.DrawRay (mTransform.position, (Camera.main.transform.position - mTransform.position));
				if (Physics.Raycast (mTransform.position, (Camera.main.transform.position - mTransform.position), out hit)) {
						if (hit.transform != Camera.main.transform) {
								return false;
						} else {
								return true;
						}
				} else {
						return false;
				}
		}

}
