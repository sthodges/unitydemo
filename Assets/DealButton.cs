using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealButton : MonoBehaviour {

	[SerializeField] private Sprite dealButtonNormal;
	[SerializeField] private Sprite dealButtonMouseOver;

	[SerializeField] private SetSolitaireGame theGame;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnMouseDown(){
		//Debug.Log ("Deal With It");
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		if (sprite != null) {			
			//sprite.sprite.
			theGame.deal();
		}
	}


	public void OnMouseUp(){
		//Debug.Log ("Deal With It");
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		if (sprite != null) {			
			//sprite.sprite = dealButtonMouseOver;				
		}
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
