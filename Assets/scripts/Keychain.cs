using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Keychain : MonoBehaviour {

	List<int> keys;

	// Use this for initialization
	void Start () {
		keys = new List<int>();
	}

	void addKey(int keyCode){
		this.keys.Add (keyCode);
	}

	public bool hasKey(int keyCode){
		return this.keys.Contains (keyCode);
	}
}
