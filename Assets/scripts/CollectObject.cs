using UnityEngine;
using System.Collections;

public class CollectObject : MonoBehaviour {

	// Use this for initialization
	public Cursor cursor;
	private bool showText = false;
	private string objName = "";
	void Start () {
	}
	void Update () {
		collectItem ();

	}

	void collectItem(){
		if (Input.GetKeyDown(KeyCode.E)) {
			GameObject obj = cursor.getPointedObject ();
			if (obj != null && obj.CompareTag("Collectable")) {
				showText = true;
				objName = obj.name; 
				Destroy (obj);
			}
		}
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
