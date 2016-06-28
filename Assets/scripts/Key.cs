using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {
	public int keyCode;
	public Keychain kc;

	void OnDestroy(){
		kc.addKey (keyCode);
	}
}
