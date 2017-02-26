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

/*

85 solid oval one red 
86 solid oval one green 
87 solid oval one blue 
89 solid oval two red 
90 solid oval two green 
91 solid oval two blue 
93 solid oval three red 
94 solid oval three green 
95 solid oval three blue 
101 solid diamond one red 
102 solid diamond one green 
103 solid diamond one blue 
105 solid diamond two red 
106 solid diamond two green 
107 solid diamond two blue 
109 solid diamond three red 
110 solid diamond three green 
111 solid diamond three blue 
117 solid squiggle one red 
118 solid squiggle one green 
119 solid squiggle one blue 
121 solid squiggle two red 
122 solid squiggle two green 
123 solid squiggle two blue 
125 solid squiggle three red 
126 solid squiggle three green 
127 solid squiggle three blue 
149 shaded oval one red 
150 shaded oval one green 
151 shaded oval one blue 
153 shaded oval two red 
154 shaded oval two green 
155 shaded oval two blue 
157 shaded oval three red 
158 shaded oval three green 
159 shaded oval three blue 
165 shaded diamond one red 
166 shaded diamond one green 
167 shaded diamond one blue 
169 shaded diamond two red 
170 shaded diamond two green 
171 shaded diamond two blue 
173 shaded diamond three red 
174 shaded diamond three green 
175 shaded diamond three blue 
181 shaded squiggle one red 
182 shaded squiggle one green 
183 shaded squiggle one blue 
185 shaded squiggle two red 
186 shaded squiggle two green 
187 shaded squiggle two blue 
189 shaded squiggle three red 
190 shaded squiggle three green 
191 shaded squiggle three blue 
213 outline oval one red 
214 outline oval one green 
215 outline oval one blue 
217 outline oval two red 
218 outline oval two green 
219 outline oval two blue 
221 outline oval three red 
222 outline oval three green 
223 outline oval three blue 
229 outline diamond one red 
230 outline diamond one green 
231 outline diamond one blue 
233 outline diamond two red 
234 outline diamond two green 
235 outline diamond two blue 
237 outline diamond three red 
238 outline diamond three green 
239 outline diamond three blue 
245 outline squiggle one red 
246 outline squiggle one green 
247 outline squiggle one blue 
249 outline squiggle two red 
250 outline squiggle two green 
251 outline squiggle two blue 
253 outline squiggle three red 
254 outline squiggle three green 
255 outline squiggle three blue 

----------
 Bit Keys
----------

     Color
1]    1 Red
2]    2 Green
3]    3 Blue

     Count
1]    4 One
2]    8 Two
3]   12 Three

     Shape
1]   16 Oval
2]   32 Diamond
3]   48 Squiggle

     Fill
1]   64 Solid
2]  128 Shaded
3]  192 Outline

Cards:  112px x 175px ( 175 pixels high 112 pixels wide )
Glyphs: 75px x 38px ( 38 pixels high 75 pixels wide )


*/
