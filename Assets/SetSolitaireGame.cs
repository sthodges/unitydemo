using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSolitaireGame : MonoBehaviour {

	private Deck deck;
	[SerializeField] private Sprite[] glyphImages;
	[SerializeField] private GameObject cardPrefab;

	private float _XLEFT = -5.0f;
	private float _XOFFSET = 1.85f;
	private float _YTOP = 3.5f;
	private float _YOFFSET = 2.2f;

	private GameObject[] cardObjects;
	private Card[] cardScripts;

	private HashSet<int> selectedCards; // the cards,(TODO: by value or by index?) clicked on

	// are usual 12 cards on the table or extra 15
	private bool fifteen;

	// game in progress
	private bool playing;

	// game play time
	private float startTime;

	// game score
	private int score;

	// scoring features
	private const int setCompletedScore = 20;
	private const int badSelectionScore = -10;
	private const int dealButtonScore = -5;


	// Use this for initialization
	void Start () {
		deck = new Deck ();
		deck.shuffle ();

		fifteen = false;
		playing = false;

		selectedCards = new HashSet<int> ();
		/*
		int cardValue;
		int color; // 0-2
		int shape; // 0-2
		int fill; // 0-2
		int count; // 0-2

		int arrayIndexOfCard;
		*/
		cardObjects = new GameObject[15];
		cardScripts = new Card[15];

		// testing code
		for(int i=0; i<15; i++){
			cardObjects [i] = Instantiate (cardPrefab) as GameObject;
			cardObjects [i].transform.position = new Vector3 (_XLEFT + _XOFFSET * (i/3), _YTOP - _YOFFSET * (i%3), 0);
			cardScripts[i] = cardObjects[i].GetComponent<Card> ();

			cardScripts [i].setIndex (i); // set the index of each card so we know later when its clicked
			cardScripts[i].parent = this; // so card can invoke members in here!

			cardScripts [i].setCardValue (-1);
			cardScripts [i].redraw ();
			//cardScripts [i].glyph = null;

			// make the card represent an empty spot on the board
			/*
			cardValue = deck.getCard();
			cardScripts[i].setCardValue( cardValue );

			color = (cardValue & 3) -1; // 0,1,2
			shape = (cardValue & 48) / 16 -1; // 0,1,2
			fill = (cardValue & 192) / 64 -1; // 0,1,2
			count = (cardValue & 12) / 4 ; // not -1 so 1, 2, or 3

			arrayIndexOfCard = color * 9 + shape * 3 + fill;

			Sprite image = glyphImages [arrayIndexOfCard];
			cardScripts [i].glyph = image;

			cardScripts [i].setCount (count);
			*/


		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// do these three cards (by value) make a set?
	private bool isASet(int [] cardIndexes){
		int[] cardValues = new int[3];
		int attribA, attribB, attribC; 
		//Debug.Log (" [1] " + cardIndexes [0] + "     [2] " + cardIndexes [1] + "     [3] " + cardIndexes [2]); // good

		for (int i = 0; i < 3; i++) {
			cardValues [i] = cardScripts [cardIndexes [i]].getCardValue ();
		//	Debug.Log(cardValues[i]);
		}
		
		// check color
		attribA = cardValues [0] & 3;
		attribB = cardValues [1] & 3;
		attribC = cardValues [2] & 3;
		//Debug.Log (attribA);
		//Debug.Log (attribB);
		//Debug.Log (attribC);


		//if (!(allMatch (attribA, attribB, attribC) || allDiffer (attribA, attribB, attribC)))
		if ((!allMatch (attribA, attribB, attribC)) && (!allDiffer (attribA, attribB, attribC))) {
			return false;
		} 

		// check shape
		attribA = cardValues [0] & 48;
		attribB = cardValues [1] & 48;
		attribC = cardValues [2] & 48;
		if ((!allMatch (attribA, attribB, attribC)) && (!allDiffer (attribA, attribB, attribC))){
			return false;
		} 


		// check fill
		attribA = cardValues [0] & 192;
		attribB = cardValues [1] & 192;
		attribC = cardValues [2] & 192;
			if ((!allMatch (attribA, attribB, attribC)) && (!allDiffer (attribA, attribB, attribC))){
			return false;
		} 

		//check count
		attribA = cardValues [0] & 12;
		attribB = cardValues [1] & 12;
		attribC = cardValues [2] & 12;
		if ((!allMatch (attribA, attribB, attribC)) && (!allDiffer (attribA, attribB, attribC))){
			return false;
		}


		return true;
	}

	private bool allMatch(int a, int b, int c){
		return (a == b && b == c);
	}

	private bool allDiffer(int a, int b, int c){
		return (a != b && b != c && a != c);
	}



	private void checkForThreeCardsSelected(){
		int[] cardArray = new int[3];
		bool result;

		if (selectedCards.Count == 3) {
			HashSet<int>.Enumerator e = selectedCards.GetEnumerator ();
			//Debug.Log (e.Current);
			e.MoveNext ();
			cardArray [0] = e.Current;
			e.MoveNext ();
			cardArray [1] = e.Current;
			e.MoveNext ();
			cardArray [2] = e.Current;

			result = isASet (cardArray);
			if (!result) {
				cardScripts [cardArray [0]].setAsBadCard ();
				cardScripts [cardArray [1]].setAsBadCard ();
				cardScripts [cardArray [2]].setAsBadCard ();
				score += badSelectionScore;

			} else {
				//Debug.Log ("OMG a match!");
				cardScripts [cardArray [0]].matched ();
				cardScripts [cardArray [1]].matched ();
				cardScripts [cardArray [2]].matched ();
				// clear HashSet
				score += setCompletedScore;
				replaceCards (cardArray);
				selectedCards.Clear ();
			}
		}
	}


	public void replaceCards(int []targets){
		cardScripts [targets [0]].setCardValue(-1);
		cardScripts [targets [0]].redraw ();

		cardScripts [targets [1]].setCardValue(-1);
		cardScripts [targets [1]].redraw ();

		cardScripts [targets [2]].setCardValue(-1);
		cardScripts [targets [2]].redraw ();

		if (fifteen) {
			// so if there were fifteen cards, don't deal out three new ones
			// and instead drop to twelve
			fifteen = false;
			return;
		}
		// here deal out three new cards to replace the cards that were matched
		// TODO -- some sort of animation or delay here
		dealOneCardTo(targets[0]);
		dealOneCardTo(targets[1]);
		dealOneCardTo(targets[2]);


	}


	// TODO: a new function to deal one card as helper for various spots in here/the next function????
	// TODO: use the dealACard(index) helper function where appropriate

	public void deal(){
		//Debug.Log ("SetSolitaireGame ----> DEAL");
		int cardValue;
		int color; // 0-2
		int shape; // 0-2
		int fill; // 0-2
		int count; // 0-2
		int arrayIndexOfCard;
		if (!playing) {
			playing = true;
			fifteen = false;

	

			// testing code
			for (int i = 0; i < 12; i++) {
				// make the card the next one dealt from the deck
				cardValue = deck.getCard ();
				cardScripts [i].setCardValue (cardValue);

				color = (cardValue & 3) - 1; // 0,1,2
				shape = (cardValue & 48) / 16 - 1; // 0,1,2
				fill = (cardValue & 192) / 64 - 1; // 0,1,2
				count = (cardValue & 12) / 4; // not -1 so 1, 2, or 3

				arrayIndexOfCard = color * 9 + shape * 3 + fill;

				Sprite image = glyphImages [arrayIndexOfCard];
				cardScripts [i].glyph = image;

				cardScripts [i].setCount (count);
				cardScripts [i].redraw ();


				// start the game timer!
				startTime = Time.time;

			}



		} else {
			// was already playing
			if (!fifteen) {
				// best place for score adjustments
				score += dealButtonScore;

				fifteen = true;
				int index = 0;
				int cardsToDeal = 3;
				while (cardsToDeal > 0) {
					if (cardScripts [index].getCardValue () == -1) {
						// found an ampty spot to deal into
						cardValue = deck.getCard ();
						cardScripts [index].setCardValue (cardValue);

						color = (cardValue & 3) - 1; // 0,1,2
						shape = (cardValue & 48) / 16 - 1; // 0,1,2
						fill = (cardValue & 192) / 64 - 1; // 0,1,2
						count = (cardValue & 12) / 4; // not -1 so 1, 2, or 3

						arrayIndexOfCard = color * 9 + shape * 3 + fill;

						Sprite image = glyphImages [arrayIndexOfCard];
						cardScripts [index].glyph = image;

						cardScripts [index].setCount (count);
						cardScripts [index].redraw ();

						cardsToDeal -= 1;
					} else {
						index++;
					}
				}
				// wasn't fifteen
			} else {
				// was fifteen cards
				;
				// so nothing happens and no penalty?
			}
		} // was playing
	} // deal

	private void dealOneCardTo(int index){


		int cardValue;
		int color; // 0-2
		int shape; // 0-2
		int fill; // 0-2
		int count; // 0-2
		int arrayIndexOfCard;

		cardValue = deck.getCard();
		cardScripts[index].setCardValue( cardValue );

		color = (cardValue & 3) -1; // 0,1,2
		shape = (cardValue & 48) / 16 -1; // 0,1,2
		fill = (cardValue & 192) / 64 -1; // 0,1,2
		count = (cardValue & 12) / 4 ; // not -1 so 1, 2, or 3

		arrayIndexOfCard = color * 9 + shape * 3 + fill;

		Sprite image = glyphImages [arrayIndexOfCard];
		cardScripts [index].glyph = image;

		cardScripts [index].setCount (count);
		cardScripts [index].redraw ();

	}


	public void clickedOn(int index){
		// player just clicked on card with index index
		// now figure out what to do
		//Debug.Log(index);
		selectedCards.Add (index);
		checkForThreeCardsSelected();
	}


	public void clickedOff(int index){
		// player just clicked on card with index index
		// now figure out what to do
		//Debug.Log(index);
		selectedCards.Remove (index);
	}


	public void OnGUI(){
		if (playing) {
			// timer
			float guiTime = Time.time - startTime;
			int minutes = (int)guiTime / 60;
			int seconds = (int)guiTime % 60;
			int fraction = (int)(guiTime * 100) % 100;
			string result = string.Format ("{0:00}:{1:00}:{2:000}", minutes, seconds, fraction); 
			GUI.Label (new Rect (675, 250, 100, 30), result); 
			// score
			result = string.Format("{000000}", score);
			GUI.Label (new Rect (685, 155, 100, 30), result);
		
		}



	}

}


// TODO:  align label coordinates to display boxes
// TODO:  game end condition and bottom of the deck addtiions
