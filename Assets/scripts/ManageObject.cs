using UnityEngine;
using System.Collections;

public class ManageObject : MonoBehaviour {

	public Cursor cursor;
	bool carrying;
	GameObject mainCamera;
	GameObject carriedObject;
	public float distance;
	public float smooth;
	private bool showText;
	private string objName;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
		this.showText = false;
		this.objName = "";
	}

	// Update is called once per frame
	void Update () {
		if(carrying){
			carry (carriedObject);
			checkDrop ();

		}else{
			manageObject ();
		}
	}

	void carry(GameObject o){
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
		o.transform.rotation = Quaternion.identity;
	}

	void manageObject(){
		if (Input.GetKeyDown (KeyCode.E)) {
			GameObject o = cursor.getPointedObject ();
			if (o != null) {
				switch (o.tag) {
				case "Pickupable":
					pickup (o);
					break;
				case "Collectable":
					collect (o);
					break;
				case "Door":
					manageDoor (o);
					break;
				}
			}
		}
	}

	void pickup(GameObject o){
		carrying = true;
		carriedObject = o;
		//carriedObject.GetComponent<Rigidbody>().isKinematic = true;
		carriedObject.GetComponent<Rigidbody>().useGravity = false;			
	}

	void checkDrop(){
		if(Input.GetKeyDown(KeyCode.E)){
			dropObject();
		}
	}

	void dropObject(){
		carrying = false;
		//carriedObject.GetComponent<Rigidbody>().isKinematic = false;
		carriedObject.GetComponent<Rigidbody>().useGravity = true;
		carriedObject = null;
	}

	void collect(GameObject o){
		showText = true;
		objName = o.name; 
		Destroy (o);			
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

	void manageDoor(GameObject o){
		Door d = o.GetComponent<Door> ();
		if (d != null) {
			d.manageDoor ();
		} else {
			//ESTA PUERTA NO DEBE ABRIRSE
			Debug.Log ("Esta puerta no se abrira nunca en el juego");
		}
	}
}
