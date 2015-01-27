using UnityEngine;
using System.Collections;

public class AutoWalkSwitch : MonoBehaviour {
	public Transform walkArea;
	public bool canChange = true;
	private bool colliding,lookingFoot,movingState = false;
	private Transform _transform;
	// Use this for initialization
	void Start () {
		_transform = transform;
		walkArea.gameObject.renderer.material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 fwd = _transform.TransformDirection (Vector3.forward);
		Debug.DrawRay (_transform.position, fwd);
		if (Physics.Raycast (_transform.position, fwd, out hit, 2f)) 
		{
			//print (hit.transform.name + " has been hit");
			if(hit.transform.collider.enabled && !hit.transform.name.Equals("footprint") && !lookingFoot && movingState)
			{
				//Debug.Log ("colliding and not looking foot so he cant move");
				AutoWalkVR.autoWalk = false;
			}


			if (hit.transform.name.Equals ("footprint")) 
			{
				lookingFoot = true;
				if (canChange) 
				{
					//Debug.Log ("he hitted his foot!. Changing state...: "+canChange+ " | walk BEFORE is: "+AutoWalkVR.autoWalk);
					//AutoWalkVR.autoWalk = !AutoWalkVR.autoWalk;
					if(movingState)  AutoWalkVR.autoWalk = false;
					else AutoWalkVR.autoWalk = true;

					if (AutoWalkVR.autoWalk) 
					{
						movingState = true;
						walkArea.gameObject.renderer.material.color = Color.green;
					} 
					else 
					{
						movingState = false;
						walkArea.gameObject.renderer.material.color = Color.red; 
					}
					canChange = false;
				}

			}
			else
			{
				lookingFoot = false;
			}
			//Debug.Log ("Looking his feet: "+lookingFoot);
		} 
		else 
		{
			canChange = true;
			//Debug.Log ("not colliding and awaiting state is: "+movingState+ " is he looking his feet? "+lookingFoot);
			if(movingState&&!lookingFoot)  
			{
				AutoWalkVR.autoWalk = true;
			}
		}
	}
}
