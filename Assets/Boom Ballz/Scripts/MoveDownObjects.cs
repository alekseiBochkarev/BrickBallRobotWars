using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDownObjects : MonoBehaviour {

	private bool moveBrickDown = false;
	private float newPositionY = 0;
	private bool firstRow = true;
	public Rigidbody2D rb;
	private GameObject ballMain;
	MoveDownObjects moveDownObjectsScript;
	private float movingDownStep; //= 0.04f;
	/*
	public Vector2 bottomLeft;
	public Vector2 bottomRight;
	public Vector2 topLeft;
	*/
	public Vector2 topRight;
	private float brickSize;
	
	
	void Start() {
		moveDownObjectsScript = GetComponent<MoveDownObjects> ();
		ballMain = GameObject.Find("ballMain");
		/*
		bottomLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); // bottom-left corner
		bottomRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
		topRight = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); // top-right corner
		topLeft = Camera.main.ViewportToWorldPoint(new Vector2(0, 1));
		*/
		topRight = ballMain.GetComponent<MainBall>().topRight;
		brickSize = ballMain.GetComponent<MainBall>().brickSize;
		movingDownStep = brickSize;
	}

	public void MoveObjectkDown() {
		moveBrickDown = true;
		//newPositionY = rb.transform.position.y - 0.85f;
		newPositionY = rb.transform.position.y - brickSize;
	}

	void FixedUpdate() {
		if (firstRow) {
			//Debug.Log("this place with firstRow");
			rb.transform.position = new Vector2 (rb.transform.position.x, rb.transform.position.y - movingDownStep);
			//if (rb.transform.position.y <= 4.55f) {
			if (rb.transform.position.y <= topRight.y - brickSize * 3.5f) {
				rb.transform.position = new Vector2 (rb.transform.position.x, (topRight.y - brickSize*3.5f));
				firstRow = false;
				moveDownObjectsScript.enabled = false;
			}
		}
		if (moveBrickDown) {
			if (rb.transform.position.y > newPositionY) {
				rb.transform.position = new Vector2 (rb.transform.position.x, rb.transform.position.y - movingDownStep);
				if (rb.transform.position.y <= -2.30f) {
					if (this.gameObject.name.Contains ("brick")) {
						Lose();
						Destroy (this.gameObject);
					} else {
						Destroy (this.gameObject);
					}
				}
			} else {
				moveBrickDown = false;
				rb.transform.position = new Vector2 (rb.transform.position.x, newPositionY);
				moveDownObjectsScript.enabled = false;
			}
		}
	}

	public void Lose ()
    {
		Debug.Log("Lose");
		GameObject.Find("Canvas").GetComponent<Menus>().ShowGameoverMenu();

	}

}
