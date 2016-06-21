using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public float smooth;
	float targetRotY;
	Quaternion closedRot;
	bool isMoving;
	public bool isOpen;

	// Use this for initialization
	void Start () {
		this.closedRot = transform.rotation;
		this.isMoving = false;
	}

	void Update(){
		this.automaticClose();
		this.move();
	}

	public void manageDoor(){
		if (!this.isOpen) {
			this.open();
		} else {
			this.close();
		}
	}

	void automaticClose(){
		if (this.isOpen) {
			
		}
	}

	void move(){
		if (this.isMoving) {
			transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(closedRot.eulerAngles.x, targetRotY, 
				closedRot.eulerAngles.z), Time.deltaTime * 
				smooth);
			if (transform.rotation.eulerAngles.y == targetRotY) {
				this.isMoving = false;
			}
		}
	}

	void open(){
		targetRotY = this.closedRot.eulerAngles.y - 90;
		this.isOpen = true;
		this.isMoving = true;
	}

	void close(){
		targetRotY = this.closedRot.eulerAngles.y;
		this.isOpen = false;
		this.isMoving = true;
	}
}
