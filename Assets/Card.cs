using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card: MonoBehaviour {

	[SerializeField] private int cardID;
	[SerializeField] private GameObject cardObject;
	[SerializeFiled] private GameObject parent;

	[SerializeField] private Sprite initialImage;
	private Sprite _image;

	private bool _selected;

	public Color highlightColor = Color.cyan;

	// Use this for initialization
	void Start () {
		_selected = false;
		_image = initialImage;
		GetComponent<SpriteRenderer> ().sprite = _image;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int getID(){
		return cardID;
	}


	public void OnMouseDown(){
		//Debug.Log("card down" + cardID);

		//GetComponent<SpriteRenderer> ().sprite = 
	}


	public void OnMouseOver(){
		//Debug.Log("card over" + cardID);
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		if (sprite != null) {
			sprite.color = highlightColor;
		}
	}

	public void OnMouseExit(){
		//Debug.Log("card exit" + cardID);
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		if (sprite != null) {
			sprite.color = Color.white;
		}
	}
}
