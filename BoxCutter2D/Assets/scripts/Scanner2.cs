using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Scanner2 : MonoBehaviour {


	//public GameObject ScanObj;

	public Color defaultColor = Color.red;
	public Color selectedColor =  Color.green;
	public Renderer mat;

	private Vector3 snaplocation;

	public Vector3 orgintouch;
	public Vector3 endtouch;
	public int FingerId=-1;
	public Touch t;
	//Text text;

	private GameObject eventsystem;

	public Scanner2(){

	}
	
	void Start() {
		mat = GetComponent<Renderer>();
		snaplocation = transform.position;
		eventsystem = GameObject.Find ("EventSystem");
	//	text=GameObject.Find("BoxCount").GetComponent<Text>();
	}

	void Update() {
		if (FingerId != -1 && Input.touchCount>0) {
			t  = Input.GetTouch(FingerId);
			transform.position = new Vector3 (t.position.x, t.position.y, transform.position.z);
		}
	}

	void OnTouchDown(Touch FingerId){
		this.FingerId = FingerId.fingerId;
		mat.material.color = selectedColor;
	}
	void OnTouchUp(){
		this.FingerId = -1;
		transform.position= snaplocation;
		mat.material.color = defaultColor;
	}
	void OnTouchStay(Touch point){
		transform.position = new Vector3(point.position.x,point.position.y,transform.position.z);
		mat.material.color = selectedColor;
	}
	void OnTouchExit(){
		mat.material.color = Color.black;
		transform.position= snaplocation;
	}

	void OnTriggerEnter(){
		mat.material.color = Color.yellow;
		selectedColor =  Color.yellow;
		eventsystem.SendMessage ("Scan");
	}

}
