using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card: MonoBehaviour {

	[SerializeField] private int cardID;
	[SerializeField] private GameObject cardObject;

	[SerializeField] private Sprite image;

	private bool _selected;

	// Use this for initialization
	void Start () {
		_selected = false;
		GetComponent<SpriteRenderer> ().sprite = image;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getID(){
		return cardID;
	}


	public void OnMouseDown(){
		Debug.Log("card" + cardID);

		//GetComponent<SpriteRenderer> ().sprite = 
	}
}
