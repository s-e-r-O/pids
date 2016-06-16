using UnityEngine;
using System.Collections;

public class CollectObject : MonoBehaviour {

	// Use this for initialization
	public Cursor cursor;
	private bool showText = false;
	void Start () {
		Cursor curs = new Cursor();	
	}
	void Update () {
		collectItem ();
	}

	GameObject collectItem(){
		GameObject obj = cursor.getPointedObject ();
		if (obj != null && obj.CompareTag("Collectable")) {
			
			if (Input.GetMouseButtonDown(0)) {
				showText = true;
				Destroy (obj);

			}
		}
		return null;
	}
	void OnGUI(){
		if (showText) {
			GUI.Label(new Rect (0,0,100,100), "Test");
		}
	}


}
