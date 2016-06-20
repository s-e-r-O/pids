using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour {
	//public Cursor cursor //Use this variable to use the cursor methods (cursor.getPointedObject())

	GameObject mainCamera;
	public float maxDistance; //maximum distance for reaching an object

	void Start () {
		this.mainCamera = GameObject.FindWithTag ("MainCamera");
	}

	void Update(){
		this.getPointedObject ();
	}

	public GameObject getPointedObject(){
		int x = Screen.width / 2;
		int y = Screen.height / 2;
		Ray ray = this.mainCamera.GetComponent<Camera>().ScreenPointToRay (new Vector3 (x, y));
		RaycastHit hit;
		if (Physics.Raycast (ray, out hit, this.maxDistance)) {
			return hit.collider.gameObject;
		}
		return null;
	}
}
