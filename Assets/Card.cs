using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card: MonoBehaviour {

	//[SerializeField] private int cardID;
	//[SerializeField] private GameObject cardObject;
	//[SerializeField] private GameObject parent;

	[SerializeField] private Sprite initialImage;
	public Sprite glyph; // any card can only have one glyph
	private int _cardValue;
	private int _count;

	[SerializeField] private Sprite _selectedSprite;
	[SerializeField] private Sprite _noMatchSprite;
	[SerializeField] private Sprite _highlightedSprite;

	[SerializeField] private Sprite _frontSprite;
	[SerializeField] private Sprite _frontOverSprite;



	private bool _selected;

	public Color highlightColor = Color.cyan;


	// new for testing
	[SerializeField] private GameObject top;  // used for 3 glyph cards 
	[SerializeField] private GameObject mid;  // used for 1 and 3 glyph cards
	[SerializeField] private GameObject bot;  // used for 3 glyph cards
	[SerializeField] private GameObject hi;   // used for 2 glyph cards
	[SerializeField] private GameObject lo;   // used for 2 glyph cards
	[SerializeField] private GameObject outline; // used for all cards




	// Use this for initialization
	void Start () {
		_selected = false;
		//_image = initialImage;
		//GetComponent<SpriteRenderer> ().sprite = _image;
		//lo.GetComponent<SpriteRenderer> ().sprite = glyph;
	}
	
	// Update is called once per frame
	void Update () {
		// update display of card (?)

	}

	//public int getID(){
	//	return cardID;
	//}


	public void setCardValue(int cardValue){
		_cardValue = cardValue;
		//lo.GetComponent<SpriteRenderer> ().sprite = glyph;

	}

	// set the number of symbols in this card
	public void setCount(int count){
		_count = count;
		lo.GetComponent<SpriteRenderer> ().sprite = null;
		hi.GetComponent<SpriteRenderer> ().sprite = null;
		top.GetComponent<SpriteRenderer> ().sprite = null;
		mid.GetComponent<SpriteRenderer> ().sprite = null;
		bot.GetComponent<SpriteRenderer> ().sprite = null;
		if (count == 2) {
			lo.GetComponent<SpriteRenderer> ().sprite = glyph;
			hi.GetComponent<SpriteRenderer> ().sprite = glyph;
		}
		if (count == 3) {
			top.GetComponent<SpriteRenderer> ().sprite = glyph;
			bot.GetComponent<SpriteRenderer> ().sprite = glyph;
		}
		if (count == 1 || count == 3) {
			mid.GetComponent<SpriteRenderer> ().sprite = glyph;
		}

	}


	public void OnMouseDown(){
		//Debug.Log("card down" + cardID);

		//GetComponent<SpriteRenderer> ().sprite = 

	}


	public void OnMouseOver(){
		Debug.Log("card over: " + _cardValue + "   with count" + _count);
		SpriteRenderer sprite = outline.GetComponent<SpriteRenderer> ();
		if (sprite != null) {
			sprite.sprite = _highlightedSprite;
		}
	}

	public void OnMouseExit(){
		//Debug.Log("card exit" + cardID);
		SpriteRenderer sprite = outline.GetComponent<SpriteRenderer> ();
		if (sprite != null) {
			sprite.sprite = null;
		}
	}
}
