using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card: MonoBehaviour {

	[SerializeField] private int cardID;
	[SerializeField] private GameObject cardObject;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void OnMouseDown(){
		Debug.Log("card");
	}
}
