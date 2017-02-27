using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card: MonoBehaviour {

	//[SerializeField] private int cardID;
	//[SerializeField] private GameObject cardObject;
	//[SerializeField] private GameObject parent;

	[SerializeField] private Sprite initialImage;
	public Sprite glyph; // any card can only have one glyph
	private int _cardValue; // needed, keep here!
	private int _count;
	private int _index; // new -- maybe important -- which index position is this card 0-14 (0 - 11 are regular, 12-14 are extra)

	[SerializeField] private Sprite _selectedSprite;
	[SerializeField] private Sprite _noMatchSprite;
	[SerializeField] private Sprite _highlightedSprite;

	[SerializeField] private Sprite _tableSprite;
	[SerializeField] private Sprite _frontSprite;


	public SetSolitaireGame parent;

	private bool _selected;
	private bool _badSelection; //  is card part of a bad selection?

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
		

	public void setCardValue(int cardValue){
		_cardValue = cardValue;
		//lo.GetComponent<SpriteRenderer> ().sprite = glyph;
		if (cardValue == -1) {
			// card was just set to blank
			_selected = false;
			_badSelection = false;
		}

	}

	public int getCardValue(){
		return _cardValue;
	}


	// manually coded setters and getters
	// TODO: review syntax for auto generation of these
	public void setIndex(int index){
		_index = index;
	}

	public int getIndex(){
		return _index;
	}

	public void redraw(){
		lo.GetComponent<SpriteRenderer> ().sprite = null;
		hi.GetComponent<SpriteRenderer> ().sprite = null;
		top.GetComponent<SpriteRenderer> ().sprite = null;
		mid.GetComponent<SpriteRenderer> ().sprite = null;
		bot.GetComponent<SpriteRenderer> ().sprite = null;

		if (_cardValue != -1) {
			GetComponent<SpriteRenderer>().sprite = _frontSprite;
			if (_count == 2) {
				lo.GetComponent<SpriteRenderer> ().sprite = glyph;
				hi.GetComponent<SpriteRenderer> ().sprite = glyph;
			}
			if (_count == 3) {
				top.GetComponent<SpriteRenderer> ().sprite = glyph;
				bot.GetComponent<SpriteRenderer> ().sprite = glyph;
			}
			if (_count == 1 || _count == 3) {
				mid.GetComponent<SpriteRenderer> ().sprite = glyph;
			}

		} else {
			// -1 == no card here
			GetComponent<SpriteRenderer>().sprite = _tableSprite;
		}
	}


	// set the number of symbols in this card and then render it
	public void setCount(int count){
		_count = count;

		redraw ();
	}


	public void OnMouseDown(){
		//Debug.Log("card down" + cardID);
		if (_cardValue == -1) return;

		//GetComponent<SpriteRenderer> ().sprite = 
		_selected = ! _selected;

		SpriteRenderer sprite = outline.GetComponent<SpriteRenderer> ();
		if (sprite != null) {
			if (_selected) {
				sprite.sprite = _selectedSprite;
				//Debug.Log (" clicked card index " + _index + "    with value " + _cardValue); // good here
				parent.clickedOn (_index);
			} else {
				sprite.sprite = null;
				//Debug.Log (" UNclicked card index " + _index + "    with value " + _cardValue); // good here
				parent.clickedOff (_index);
				_badSelection = false;
			}
		}

	}


	public void OnMouseOver(){

		if (_cardValue == -1) return;

		//Debug.Log("card over: " + _cardValue + "   with count" + _count);
		SpriteRenderer sprite = outline.GetComponent<SpriteRenderer> ();
		if (sprite != null) {
			if (_selected) {
				if (_badSelection) {
					sprite.sprite = _noMatchSprite;
				} else {
					sprite.sprite = _selectedSprite;
					}
			} else {
				sprite.sprite = _highlightedSprite;
			}
		}
	}

	public void OnMouseExit(){
		if (_cardValue == -1) return;


		//Debug.Log("card exit" + cardID);
		SpriteRenderer sprite = outline.GetComponent<SpriteRenderer> ();
		if (sprite != null) {
			if (_selected) {
				if (_badSelection) {
					sprite.sprite = _noMatchSprite;
				} else {
					sprite.sprite = _selectedSprite;
				}
			} else {
				sprite.sprite = null;
			}
		}
	}

	// card was one of three selected cards
	// that doesn't make a set
	public void setAsBadCard(){
		_badSelection = true;
		SpriteRenderer sprite = outline.GetComponent<SpriteRenderer> ();
		if (sprite != null) {
				sprite.sprite = _noMatchSprite;	
		}


	}


	// card was one of three selected cards
	// that makes make a set
	public void matched(){
		_badSelection = false;
		_selected = false;
		SpriteRenderer sprite1 = outline.GetComponent<SpriteRenderer> ();
		if (sprite1 != null) {
			sprite1.sprite = null;	
		}
		SpriteRenderer sprite = GetComponent<SpriteRenderer> ();
		if (sprite != null) {
			sprite.sprite = null;	
		}

	}


}
