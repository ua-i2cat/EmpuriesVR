using UnityEngine;
using System.Collections;

public class AutoWalk : MonoBehaviour
{
		public float speed = 4f;
		public bool autoWalk = false;
		public Transform walkArea;
		public bool canChange = true;
		public Transform walkerRig;
		private Transform _transform;
		// Use this for initialization
		void Start ()
		{
				_transform = transform;
				walkArea.gameObject.renderer.material.color = Color.red;
		}
	
		// Update is called once per frame
		void Update ()
		{
				RaycastHit hit;
				Vector3 fwd = _transform.TransformDirection (Vector3.forward);
				Debug.DrawRay (_transform.position, fwd);
				if (Physics.Raycast (_transform.position, fwd, out hit, 1f)) {
						print (hit.transform.name + "hit");
						if (hit.transform.name.Equals ("footprint")) {
								if (canChange) {
										autoWalk = !autoWalk;
										if (autoWalk) {
												walkArea.gameObject.renderer.material.color = Color.green;
										} else {
												walkArea.gameObject.renderer.material.color = Color.red; 
										}
								
										canChange = false;
								}
						} 
				} else {
						canChange = true;		
				}
				if (autoWalk) {
						 
					walkerRig.transform.Translate (walkerRig.transform.forward* speed * Time.deltaTime,Space.World);
					Vector3 globalRotation=new Vector3(walkerRig.transform.rotation.x,_transform.rotation.eulerAngles.y,walkerRig.transform.rotation.z);
					walkerRig.transform.rotation=Quaternion.Euler(globalRotation);
				}
		}
}
