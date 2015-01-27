using UnityEngine;
using System.Collections;

public class AutoRotation : MonoBehaviour {

	public Transform directionRuler;

	private float rotationY = 0F;
	public float smooth=20f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		rotationY =directionRuler.rotation.eulerAngles.y;
		//rotationY = Mathf.Clamp (rotationY, minimumY, maximumY);


		Quaternion target = Quaternion.Euler(transform.localEulerAngles.x, rotationY, transform.localEulerAngles.z);
		 
		transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * smooth);
		//transform.Translate(newDirection*speed);
	}
}
