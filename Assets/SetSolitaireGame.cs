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


	// Use this for initialization
	void Start () {
		deck = new Deck ();
		deck.shuffle ();

		cardObjects = new GameObject[15];
		cardScripts = new Card[15];

		// testing code
		for(int i=0; i<15; i++){
			cardObjects [i] = Instantiate (cardPrefab) as GameObject;
			cardObjects [i].transform.position = new Vector3 (_XLEFT + _XOFFSET * (i/3), _YTOP - _YOFFSET * (i%3), 0);
			cardScripts[i] = cardObjects[i].GetComponent<Card> ();

			Sprite rndImage = glyphImages [Random.Range (0, 26)];
			cardScripts [i].glyph = rndImage;

		}


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
