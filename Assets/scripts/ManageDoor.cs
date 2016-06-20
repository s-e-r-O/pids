using UnityEngine;
using System.Collections;

public class ManageDoor : MonoBehaviour {
	public Cursor cursor;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		this.manageDoor ();
	}

	void manageDoor(){
		if (Input.GetKeyDown (KeyCode.E)) {
			GameObject o = this.cursor.getPointedObject();
			if (o != null && o.CompareTag("Door")) {
				Door d = o.GetComponent<Door> ();
				if (d != null) {
					d.manageDoor ();
				} else {
					//ESTA PUERTA NO DEBE ABRIRSE
					Debug.Log("Esta puerta no se abrira nunca en el juego");
				}
			}
		}
	}
}
