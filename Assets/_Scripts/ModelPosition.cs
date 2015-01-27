using UnityEngine;
using System.Collections;

public class ModelPosition : MonoBehaviour {
	public Transform targetObject;
	public float amount=1f;
	public float amountRotation=1f;
	public float amountScale=0.5f;
	public dfLabel posLabel;
	public dfLabel rotLabel;
	public dfLabel scaleLabel;
	// Use this for initialization
	void Start () {
		PrintTransform ();
	}
	
	 
	public void MoveUp(){
		if (targetObject != null) {
			targetObject.transform.Translate (new Vector3 (0, amount, 0));	
		}
		PrintTransform ();
	}
	public void MoveDown(){
		if (targetObject != null) {
			targetObject.transform.Translate (new Vector3 (0, -amount, 0));	
		}
		PrintTransform ();
	}
	public void MoveRight(){
		if (targetObject != null) {
			targetObject.transform.Translate (new Vector3 (amount,0 , 0));	
		}
		PrintTransform ();
	} 
	public void MoveLeft(){
		if (targetObject != null) {
			targetObject.transform.Translate (new Vector3 (-amount,0 , 0));	
		}
		PrintTransform ();
	}

	public void MoveForward(){
		if (targetObject != null) {
			targetObject.transform.Translate (new Vector3 (0,0 , amount));	
		}
		PrintTransform ();
	}
	public void MoveBackward(){
		if (targetObject != null) {
			targetObject.transform.Translate (new Vector3 (0,0 , -amount));	
		}
		PrintTransform ();
	}
	public void RotateRight(){
		if (targetObject != null) {
			targetObject.transform.Rotate (new Vector3 (0 ,amount, 0));	
		}
		PrintTransform ();
	} 
	public void RotateLeft(){
		if (targetObject != null) {
			targetObject.transform.Rotate (new Vector3 (0,-amount , 0));	
		}
		PrintTransform ();
	}
	public void ScaleUp(){
		if (targetObject != null) {
			targetObject.localScale+=new Vector3(amount,amount,amount);	
		}
		PrintTransform ();
	} 
	public void ScaleDown(){
		if (targetObject != null) {
			targetObject.localScale-=new Vector3(amount,amount,amount);	
		}
		PrintTransform ();
	}
	private void PrintTransform(){
		posLabel.Text="X="+targetObject.localPosition.x+" y="+targetObject.localPosition.y+" z="+targetObject.localPosition.z;
		rotLabel.Text="X="+targetObject.localEulerAngles.x+" y="+targetObject.localEulerAngles.y+" z="+targetObject.localEulerAngles.z;
		scaleLabel.Text="Scale="+targetObject.localScale.x;
	}
}
