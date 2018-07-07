using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

	#region Variables
	Text	txt;

	public int score = 0;
	#endregion Variables

	#region Functions
	void Start () {
		txt	=	GetComponent<Text>();
	}
	

	void Update () {
		PrintScore();
	}
	#endregion Functions

	public void AddToScoreVoid(){

		score	=	score + 1;
		PrintScore();
	}

	public void PrintScore(){

		txt.text	=	"Score: "	+	score;
	}
} // Main class
