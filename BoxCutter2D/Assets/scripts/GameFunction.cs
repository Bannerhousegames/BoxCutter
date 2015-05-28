using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;



public class GameFunction : MonoBehaviour {

	List<BoxCard> BoxList = new List<BoxCard>();
	public GameObject Damage01;
	public GameObject Damage02;
	public GameObject Damage03;
	public GameObject ThisSideWrong;
	public GameObject ThisSideUp;
	public GameObject Taped01;
	public GameObject Taped02;
	public GameObject Scanned;
	public GameObject Signed;
	public GameObject ScannerAnimation;

	public Animator anim;
	int currentBox;
	int loadedBox;
	Text text;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		currentBox=0;
		loadedBox=-1;
		BoxList.Add(new BoxCard(1,0,0,0,0,0,0,0));
		BoxList.Add(new BoxCard(0,1,0,0,0,0,0,0));
		BoxList.Add(new BoxCard(0,0,1,0,0,0,0,0));
		BoxList.Add(new BoxCard(1,0,0,1,0,0,0,0));
		BoxList.Add(new BoxCard(0,1,0,0,1,0,0,0));
		BoxList.Add(new BoxCard(0,0,1,0,0,1,0,0));
		BoxList.Add(new BoxCard(1,0,0,0,0,0,1,0));
		BoxList.Add(new BoxCard(0,1,0,0,0,0,0,1));
		BoxList.Add(new BoxCard(1,0,0,0,0,0,0,0));
		BoxList.Add(new BoxCard(0,1,0,0,0,0,0,0));
		BoxList.Add(new BoxCard(0,0,1,0,0,0,0,0));
		BoxList.Add(new BoxCard(0,0,1,0,0,0,0,0));
	}
	
	// Update is called once per frame
	void Update () {
		if (loadedBox != currentBox) {
			BoxList[currentBox].LoadImages(this);
			loadedBox=currentBox;
			text=GameObject.Find("BoxCount").GetComponent<Text>();
			text.text = "Boxcount: "+(currentBox+1);
		
		}
	}
	public void NewBox(){
		currentBox++;
		if (currentBox >= BoxList.Count) {
			currentBox = 0;
		}
	}

	public void Scan(){
		BoxList[currentBox].Scan(this);
		Animator a = ScannerAnimation.GetComponent<Animator>();
		a.SetTrigger ("scanning");
	}

	public void FlipBox(){
		BoxList[currentBox].FlipBox();
		BoxList[currentBox].LoadImages(this);
	}

}


public class BoxCard : IComparable<BoxCard> {

	int isDamaged1;
	int isDamaged2;
	int isDamaged3;
	
	int isFlipped;
	int isTaped1;
	int isTaped2;
	int isScanned;
	int isSigned;
	
	int hasFlipped;
	int hasTaped1;
	int hasTaped2;
	int hasScanned;
	int hasSigned;

	int foodType1 = 0;
	int foodType2 = 0;
	int foodType3 = 0;

	int boxrandom = 0;
	int errorCount =0;



	// Use this for initialization
	void Start () {
		
	}
	public int CompareTo(BoxCard other){
		if (other == null)
			return 1;
		return boxrandom - other.boxrandom;
	}


	public BoxCard(int damage1,int damage2,int damage3,int flipped,int taped1,int taped2,int scanned, int signed){
		isDamaged1 = damage1;
		isDamaged2 = damage2;
		isDamaged3 = damage3;
		isFlipped = flipped;
		isTaped1 = taped1;
		isTaped2 = taped2;
		isScanned = scanned;
		isSigned = signed;
		UnityEngine.Random.seed = 42;

		boxrandom = Mathf.RoundToInt (UnityEngine.Random.value);
	}	

	public void LoadImages(GameFunction a){
		if (isDamaged1 == 1) {a.Damage01.SetActive (true);} else {a.Damage01.SetActive (false);}
		if (isDamaged2 == 1) {a.Damage02.SetActive(true);} else {a.Damage02.SetActive (false);}
		if (isDamaged3 == 1) {a.Damage03.SetActive(true);} else {a.Damage03.SetActive (false);}
		if (isFlipped == 1 && hasFlipped == 0 ) {a.ThisSideWrong.SetActive(true);} else {a.ThisSideWrong.SetActive (false);}
		if (isFlipped == 0 && hasFlipped == 1 ) {a.ThisSideUp.SetActive(true);} else {a.ThisSideUp.SetActive (false);}
		if (isTaped1 == 1) {a.Taped01.SetActive(true);} else {a.Taped01.SetActive (false);}
		if (isTaped2 == 1) {a.Taped02.SetActive(true);} else {a.Taped02.SetActive (false);}
		if (isScanned == 1) {a.Scanned.SetActive(true);} else {a.Scanned.SetActive (false);}
		if (isSigned == 1) {a.Signed.SetActive(true);} else {a.Signed.SetActive (false);}

	}

	public void Scan(GameFunction a){
		if (isScanned == 1) {
			hasScanned = 1;
			//	a.anim.SetTrigger ("scanning");
		}
	}

	public void FlipBox(){
		if (isFlipped == 1){
				isFlipped = 0;
				hasFlipped = 1;
			}
		}

	
	
}
