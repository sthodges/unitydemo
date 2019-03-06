// Steve J. Hodges, 2d Card Game Unity Example
// Cabrillo College, sthodges@cabrillo.edu

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealButton : MonoBehaviour {

	[SerializeField] private Sprite dealButtonNormal;
	[SerializeField] private Sprite dealButtonMouseOver;

	[SerializeField] private SetSolitaireGame theGame;


	private bool unnecessaryDebounce;

	// Use this for initialization
	void Start () {
		unnecessaryDebounce = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseDown(){
		//Debug.Log ("Deal With It");

		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		transform.localScale = new Vector3 (1.1f, 1.1f, 1.1f);

		if (unnecessaryDebounce) {
			unnecessaryDebounce = false;
			theGame.deal ();
		} 

	}


	public void OnMouseUp(){
		//Debug.Log ("Deal With It");
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		transform.localScale = Vector3.one;

		unnecessaryDebounce = true;
	}


	public void OnMouseOver(){
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		if (sprite != null) {			
			sprite.sprite = dealButtonMouseOver;				
		}
	}

	public void OnMouseExit(){
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		if (sprite != null) {
			if (sprite != null) {			
				sprite.sprite = dealButtonNormal;				
			}
		}
	}




}
