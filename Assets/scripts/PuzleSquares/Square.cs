using UnityEngine;
using System.Collections;

public class Square : MonoBehaviour {

	//public float smooth;
	public PuzzleTorch pzT;
	public int answerState;
	public int wallState;
	public GameObject wall;

	int state;
	//bool isMoving;
	//Vector3 targetRot;

	// Use this for initialization
	void Start () {
		this.state = 0;
	}

	// Update is called once per frame
	/*void Update () {
		//this.move();
	}

	void move(){
		if (this.isMoving) {
			if (Vector3.Distance(transform.eulerAngles, targetRot) > 0.01f)
			{
				transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, targetRot, Time.deltaTime * smooth);
			}
			else
			{
				transform.eulerAngles = targetRot;
				this.isMoving = false;
				state = (state + 1) % 4;
			}
		}
	}*/

	public void handle(){
		//if (!this.isMoving) {
		this.rotate ();
		if (!pzT.isSolved ()) {
			if (this.correctState ()) {
				pzT.tryToSolve ();
			}
		}
		/*
			switch (state) {
			case 0:
				targetRot.Set(90, 0, 0);
				break;
			case 1:
				targetRot.Set(180, 0, 0);
				break;
			case 2:
				targetRot.Set(180, 180, 180);
				break;
			case 3:
				targetRot.Set(90, 90, 0);
				break;
			}
			this.isMoving = true;*/
		//}
	}

	public bool correctState(){
		return state == answerState;
	}

	public bool correctState(int tryState){
		return this.state == tryState;
	}

	void rotate(){
		transform.Rotate (90, 0, 0);
		state = (state + 1) % 4;
		if (pzT.torchTaken ()) {
			if (state == wallState) {
				wall.SetActive (false);
			} else {
				wall.SetActive (true);
			}
		}
	}
}
