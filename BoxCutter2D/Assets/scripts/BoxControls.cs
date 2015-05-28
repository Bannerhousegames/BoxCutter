using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;



public class BoxControls : MonoBehaviour {

	public LayerMask touchInputMask;

	private List<GameObject> touchList = new List<GameObject>();
	private List<GameObject> touchesOld = new List<GameObject>();

	private List<Touch> myTouchList = new List<Touch>();
	private List<Touch> myTouchListOld = new List<Touch>();
	public GameObject EventSystem;

	RaycastHit hit;
	private bool pressed=false;
	private bool touchfound=false;
	
	Text text;
		void Start(){
		text=GameObject.Find("BoxCount").GetComponent<Text>();
	

		}
	// Update is called once per frame
	void Update () {


#if UNITY_EDITOR
	/*
		if(Input.GetMouseButton(0)|| Input.GetMouseButtonDown(0)||Input.GetMouseButtonUp(0)){
		
		
			touchesOld=touchList;
			if (pressed==false)touchList.Clear();
			

				Ray ray= GetComponent<Camera>().ScreenPointToRay(Input.mousePosition);

				
				if(Physics.Raycast(ray, out hit,touchInputMask) && pressed==false){
					GameObject recipient = hit.transform.gameObject;
					touchList.Add(recipient);
		
			 		if(Input.GetMouseButtonDown(0) && pressed==false){
						recipient.SendMessage("OnTouchDown",hit.point,SendMessageOptions.DontRequireReceiver); 
						pressed=true;
					}

				 if(Input.GetMouseButton(0) && pressed==false){
						recipient.SendMessage("OnTouchStay",hit.point,SendMessageOptions.DontRequireReceiver); 
					}

				 if(Input.GetMouseButtonUp(0) && pressed == false){
					recipient.SendMessage("OnTouchUp",hit.point,SendMessageOptions.DontRequireReceiver); 
					pressed=false;
				}

				}

				if(Input.GetMouseButton(0) && pressed == true){
					touchesOld[0].SendMessage("OnTouchDown",Input.mousePosition,SendMessageOptions.DontRequireReceiver); 
					 
					}
				if(Input.GetMouseButtonUp(0) && pressed == true){
					touchesOld[0].SendMessage("OnTouchUp",Input.mousePosition,SendMessageOptions.DontRequireReceiver); 
					pressed=false;

				}
					
					
		

				
			foreach (GameObject g in touchesOld){
				if(!touchList.Contains(g)) {
					g.SendMessage("OnTouchExit",hit.point,SendMessageOptions.DontRequireReceiver);

				
				}
			}						
			
			
		}

   */
#endif



		if (Input.touchCount > 0) {
			//touchesOld = new GameObject[touchList.Count];
			//	touchList.Copyto(touchesOld);
			touchesOld = touchList;
			touchList.Clear ();


			foreach (Touch touch in Input.touches) {
				Ray ray = GetComponent<Camera> ().ScreenPointToRay (touch.position);

				myTouchList.Add(touch);

				if (Physics.Raycast (ray, out hit, touchInputMask)) {
					GameObject recipient = hit.transform.gameObject;

					if (touch.phase == TouchPhase.Began) {
						recipient.SendMessage ("OnTouchDown",touch, SendMessageOptions.DontRequireReceiver); 
						//recipient.SendMessage ("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver); 
					}
					if (touch.phase == TouchPhase.Ended) {
						recipient.SendMessage ("OnTouchUp", touch, SendMessageOptions.DontRequireReceiver); 
					}
					if (touch.phase == TouchPhase.Stationary) {
						recipient.SendMessage ("OnTouchStay", touch, SendMessageOptions.DontRequireReceiver); 
					}
					if (touch.phase == TouchPhase.Canceled) {
						recipient.SendMessage ("OnTouchExit", touch, SendMessageOptions.DontRequireReceiver); 
					}

				}

		
			}
			foreach (GameObject g in touchesOld) {
				if (!touchList.Contains (g)) {
					g.SendMessage ("OnTouchExit", g, SendMessageOptions.DontRequireReceiver);
				}
			}		


		}

		/*Vector3 acceleration = Vector3.zero;
		int i = 0;
		while (i < Input.accelerationEventCount) {
			AccelerationEvent accEvent = Input.GetAccelerationEvent(i);
			acceleration += accEvent.acceleration * accEvent.deltaTime;
			++i;
		}
		*/

		if (Math.Abs (Input.acceleration.x) > 1.5) {
			text.text = "Accel" + Input.acceleration.x + ", " + Input.acceleration.y + ", " + Input.acceleration.z;
			EventSystem.SendMessage("FlipBox","", SendMessageOptions.DontRequireReceiver);
			}

		}




public class MyTouches{

		public Touch touch;
		public GameObject touchobject;
		public Vector3 orgintouch;
		public Vector3 endtouch;
		public float beginactiontime;
		public float currentactiontime;
		public string swipedir;
		public bool isDraggable;

		public MyTouches(Touch touch, GameObject touchobject){
			this.touch = touch;
			if (touchobject!=null) {
				this.touchobject= touchobject;

				}
				
		}

		public void Clear(){
			this.touchobject = null;
		}

	}
}




/*
  		if (Input.touchCount > 0) {
			//touchesOld = new GameObject[touchList.Count];
			//	touchList.Copyto(touchesOld);
			touchesOld = touchList;
			touchList.Clear ();

			foreach (Touch touch in Input.touches) {
				Ray ray = GetComponent<Camera> ().ScreenPointToRay (touch.position);

				if (Physics.Raycast (ray, out hit, touchInputMask)) {
					GameObject recipient = hit.transform.gameObject;

					touchList.Add (recipient);

					if (touch.phase == TouchPhase.Began) {
						recipient.SendMessage ("OnTouchDown", hit.point, SendMessageOptions.DontRequireReceiver); 
					}
					if (touch.phase == TouchPhase.Ended) {
						recipient.SendMessage ("OnTouchUp", hit.point, SendMessageOptions.DontRequireReceiver); 
					}
					if (touch.phase == TouchPhase.Stationary) {
						recipient.SendMessage ("OnTouchStay", hit.point, SendMessageOptions.DontRequireReceiver); 
					}
					if (touch.phase == TouchPhase.Canceled) {
						recipient.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver); 
					}

				}

		
			}
			foreach (GameObject g in touchesOld) {
				if (!touchList.Contains (g)) {
					g.SendMessage ("OnTouchExit", hit.point, SendMessageOptions.DontRequireReceiver);
				}
			}		


		}

*/