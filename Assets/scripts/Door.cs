using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public float smooth;
	float targetRotY;
	float closedRotY;
	bool isMoving;
	public bool isOpen;

	// Use this for initialization
	void Start () {
		this.closedRotY = transform.rotation.eulerAngles.y;
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
			transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, targetRotY, 0), Time.deltaTime * 
				smooth);
			if (transform.rotation.y == targetRotY) {
				this.isMoving = false;
			}
		}
	}

	void open(){
		targetRotY = this.closedRotY - 90;
		this.isOpen = true;
		this.isMoving = true;
	}

	void close(){
		targetRotY = this.closedRotY;
		this.isOpen = false;
		this.isMoving = true;
	}
}
