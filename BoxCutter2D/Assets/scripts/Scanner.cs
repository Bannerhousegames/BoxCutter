using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Scanner : MonoBehaviour {


	//public GameObject ScanObj;

	public Color defaultColor = Color.red;
	public Color selectedColor =  Color.green;
	public Renderer mat;

	private Vector3 snaplocation;

	public Vector3 orgintouch;
	public Vector3 endtouch;

	//Text text;

	public Scanner(){

	}
	
	void Start() {
		mat = GetComponent<Renderer>();
		snaplocation = transform.position;
	//	text=GameObject.Find("BoxCount").GetComponent<Text>();
	}
	
	void OnTouchDown(Vector3 point){

	//	text.text = "Boxcount: "+point.x+" "+point.y+" "+transform.position.z;
			transform.position = new Vector3(point.x,point.y,transform.position.z);

		mat.material.color = selectedColor;
	}
	void OnTouchUp(){
		transform.position= snaplocation;
		mat.material.color = defaultColor;
	}
	void OnTouchStay(Vector3 point){
		transform.position = new Vector3(point.x,point.y,transform.position.z);
		mat.material.color = selectedColor;
	}
	void OnTouchExit(){
		mat.material.color = Color.black;
		transform.position= snaplocation;
	}

	void OnTriggerEnter(){
		mat.material.color = Color.yellow;
		selectedColor =  Color.yellow;
	}

}
