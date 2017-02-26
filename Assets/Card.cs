using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card: MonoBehaviour {

	//[SerializeField] private int cardID;
	//[SerializeField] private GameObject cardObject;
	//[SerializeField] private GameObject parent;

	[SerializeField] private Sprite initialImage;
	public Sprite glyph; // any card can only have one glyph

	private bool _selected;

	public Color highlightColor = Color.cyan;


	// new for testing
	[SerializeField] private GameObject top;  // used for 3 glyph cards 
	[SerializeField] private GameObject mid;  // used for 1 and 3 glyph cards
	[SerializeField] private GameObject bot;  // used for 3 glyph cards
	[SerializeField] private GameObject hi;   // used for 2 glyph cards
	[SerializeField] private GameObject lo;   // used for 2 glyph cards




	// Use this for initialization
	void Start () {
		_selected = false;
		//_image = initialImage;
		//GetComponent<SpriteRenderer> ().sprite = _image;
		lo.GetComponent<SpriteRenderer> ().sprite = glyph;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//public int getID(){
	//	return cardID;
	//}


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
