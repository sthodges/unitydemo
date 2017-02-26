using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSolitaireGame : MonoBehaviour {

	private Deck deck;
	[SerializeField] private Card[] cards;
	[SerializeField] private Sprite[] glyphImages;

	// Use this for initialization
	void Start () {
		deck = new Deck ();
		deck.shuffle ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
