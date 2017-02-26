//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

using System;

public class Deck {

	private static int[] _startingDeck = {
		85, 86, 87, 89, 90, 91, 93, 94, 95, 101, 102, 103,
		105, 106, 107, 109, 110, 111, 117, 118, 119, 121,
		122, 123, 125, 126, 127, 149, 150, 151, 153, 154,
		155, 157, 158, 159, 165, 166, 167, 169, 170, 171,
		173, 174, 175, 181, 182, 183, 185, 186, 187, 189,
		190, 191, 213, 214, 215, 217, 218, 219, 221, 222,
		223, 229, 230, 231, 233, 234, 235, 237, 238, 239,
		245, 246, 247, 249, 250, 251, 253, 254, 255
	};

	private int[] _deck;
	private int _cardIndex; // next card to deal

	private Random _rng;


	// constructor
	public Deck () {
		_deck = new int[81];
		_cardIndex = 0;

		_rng = new Random ();

		for(int i=0; i<81; i++){
			_deck[i] = _startingDeck[i];	
		}
			
	}
	



	public void shuffle(){
		
		int temp;
		int randomIndex;
		for(int i=0; i<81; i++){
			randomIndex = _rng.Next (0, i);
			temp = _deck[i];
			_deck[i] = _deck[randomIndex];
			_deck[randomIndex] = temp;
		}

	}

	// TODO: add bounds checking (?) if necessary
	public int getCard(){
		int temp = _deck[_cardIndex];
		_cardIndex += 1;
		return temp;
	}



}
