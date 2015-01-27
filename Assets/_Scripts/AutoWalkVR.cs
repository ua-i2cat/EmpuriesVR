using UnityEngine;
using System.Collections;

public class AutoWalkVR : MonoBehaviour {
	public Transform forwardRuler;
	public float speed =4f;
	public static bool autoWalk = false;
 
	private Transform _transform;
	// Use this for initialization
	void Start () {
		_transform = transform;
		autoWalk = false;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (autoWalk) {
				transform.Translate (forwardRuler.forward * speed * Time.deltaTime);
		}
	}
}
