using UnityEngine;
using System.Collections;

public class MoveObjects : MonoBehaviour {

	public Cursor cursor;
	bool carrying;
	GameObject mainCamera;
	GameObject carriedObject;
	public float distance;
	public float smooth;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
		
	}
	
	// Update is called once per frame
	void Update () {
		if(carrying){
			carry (carriedObject);
			checkDrop ();
	
		}else{
			pickup ();
		}
	}

	void carry(GameObject o){
		o.transform.position = Vector3.Lerp (o.transform.position, mainCamera.transform.position + mainCamera.transform.forward * distance, Time.deltaTime * smooth);
		o.transform.rotation = Quaternion.identity;
	}

	void pickup(){
		if(Input.GetKeyDown(KeyCode.E)){
			GameObject o = cursor.getPointedObject();
			if (o != null && o.CompareTag("Pickupable")) {
				carrying = true;
				carriedObject = o;
				//carriedObject.GetComponent<Rigidbody>().isKinematic = true;
				carriedObject.GetComponent<Rigidbody>().useGravity = false;
			}
		}
			
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

}
