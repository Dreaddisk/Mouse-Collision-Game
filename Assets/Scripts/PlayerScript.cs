using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerScript : MonoBehaviour {

	#region Variables
	public float playerSpeed	=	100.0f;
	 
	Score	addToScore;
	#endregion Variables

	#region Functions
	void Start () {
		HideCursor(); 
	}
	

	void Update () {
		
		PlayerMovement();
		
	}
	#endregion Functions

	void PlayerMovement(){

		var tempMousePosition	=	Input.mousePosition;
		tempMousePosition.z		=	transform.position.z	-	Camera.main.transform.position.z;
		tempMousePosition	=	Camera.main.ScreenToWorldPoint(tempMousePosition);
		transform.position	=	Vector3.MoveTowards(transform.position, tempMousePosition,
													 playerSpeed	*	Time.deltaTime);
		
	}

	void HideCursor(){

		Cursor.visible	= false;
	}

	 void OnCollisionEnter2D(Collision2D tempCollision)
	{
		if(tempCollision.gameObject.tag	==	"Collectable"){

			CallAddToScoreScript();
			Destroy(tempCollision.gameObject);
		}

		if(tempCollision.gameObject.tag	==	"BadCollectable"){
			ResetGame();
		}
	}

	void CallAddToScoreScript(){

		addToScore	=	GameObject.FindGameObjectWithTag("GUI").GetComponent<Score>();
		addToScore.AddToScoreVoid();
	}

	void ResetGame(){

			SceneManager.LoadScene(0);
	}
} // Main class
