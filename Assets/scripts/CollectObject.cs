using UnityEngine;
using System.Collections;

public class CollectObject : MonoBehaviour {

	// Use this for initialization
	public Cursor cursor;
	private bool showText = false;
	private string objName = "";
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
				objName = obj.name; 
				Destroy (obj);

			}
		}
		return null;
	}
	void OnGUI(){
		if (showText) {
			GUI.Label(new Rect (0,0,100,100), "Encontraste : " + objName);
			StartCoroutine (Visibility ());

		}
	}
	private IEnumerator Visibility() {
		yield return new WaitForSeconds (3);
		showText = false;
	}

}
