using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class Box : MonoBehaviour {

	public Color defaultColor = Color.red;
	public Color selectedColor =  Color.green;
	public Renderer mat;

	public Vector3 orgintouch;
	public Vector3 endtouch;

	public float beginactiontime;
	public float currentactiontime;
	private bool touched=false;
	private string swipedir;

	Text text;



	void Start() {
		mat = GetComponent<Renderer>();
		text=GameObject.Find("BoxCount").GetComponent<Text>();
	}

    void OnTouchDown(Touch point){

		if (touched == false) {
			orgintouch = new Vector3(point.position.x,point.position.y,this.transform.position.z);
			beginactiontime = Time.deltaTime;
			touched = true;
		} else {
			currentactiontime+=Time.deltaTime;
		}
		mat.material.color = selectedColor;
	}
	void OnTouchUp(Touch point){
		endtouch = new Vector3(point.position.x,point.position.y,this.transform.position.z);
		mat.material.color = defaultColor;
		swipecheck();	
		currentactiontime = 0f;
		touched = false;

	}
	void OnTouchupStay(){
	 	mat.material.color = selectedColor;
	}
	void OnTouchExit(){
		mat.material.color = defaultColor;
	}

	void swipecheck(){
		if (currentactiontime - beginactiontime > .5f || Vector3.Distance(orgintouch,endtouch)<50f)
			text.text = "TooSlow/TooShort"+(Vector3.Distance(orgintouch,endtouch));

		else{

			swipedir = "";
			if (orgintouch.x < endtouch.x) {
				swipedir += " Right ";
			} else {
				swipedir += " Left ";
			}

			if (orgintouch.y < endtouch.y) {
				swipedir += " Up ";
			} else {
				swipedir += " Down ";
			}
			text.text = orgintouch+" "+endtouch+" "+swipedir+" "+(Vector3.Distance(orgintouch,endtouch));
		}
	}

	bool isDraggable(){
		selectedColor = Color.yellow;
		return false;
	}
}
