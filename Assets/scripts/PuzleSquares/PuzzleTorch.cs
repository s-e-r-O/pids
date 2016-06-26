using UnityEngine;
using System.Collections;

public class PuzzleTorch : MonoBehaviour {

	public Square[] squares;
	Torchelight tl;
	bool solved;
	bool taken;
	public GameObject playerTorch;
	public GameObject trigger;
	public GameObject firstWall;
	public Material firstWallMat;
	// Use this for initialization
	void Awake () {
		tl = GetComponent<Torchelight> ();
	}
	
	public void tryToSolve(){
		bool tempSolved = true;
		for (int i = 0; i < 4; i++) {
			if (!squares [i].correctState ()) {
				tempSolved = false;
				break;
			}
		}
		if (tempSolved) {
			this.solve ();
		}
	}

	void solve(){
		this.solved = true;
		this.tl.IntensityLight = 3;
		gameObject.tag = "Collectable";
	}

	public bool isSolved(){
		return solved;
	}

	public bool torchTaken(){
		return taken;
	}

	void OnDestroy(){
		playerTorch.SetActive(true);
		taken = true;
		firstWall.GetComponent<Renderer>().material = firstWallMat;
		Destroy (trigger);
	}
}
