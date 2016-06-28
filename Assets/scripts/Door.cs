using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public float smooth;
	public bool isOpen;
	public bool isBlocked;
	public int neededKey;

	public AudioClip openingSound;
	public AudioClip closingSound;
	public AudioClip blockedSound;

	float targetRotY;
	Quaternion closedRot;
	bool isMoving;

	private AudioSource source;



	public Keychain kc;

	void Awake(){
		this.source = GetComponent<AudioSource> ();
	}

	void Start () {
		this.closedRot = transform.rotation;
		this.isMoving = false;
	}

	void Update(){
		this.move();
	}

	public void manageDoor(){
		if (!this.isMoving) {
			if (!this.isOpen) {
				this.open();
			} else {
				this.close();
			}
		}
	}

	IEnumerator automaticClose(){
		yield return new WaitForSeconds (5);
		this.close ();
	}

	void move(){
		if (this.isMoving) {
			transform.localRotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(closedRot.eulerAngles.x, targetRotY, 
				closedRot.eulerAngles.z), Time.deltaTime * 
				smooth);
			if (Mathf.Abs(transform.rotation.eulerAngles.y - targetRotY) <= 0.5f) {
				transform.rotation.eulerAngles.Set (closedRot.eulerAngles.x, targetRotY, 
					closedRot.eulerAngles.z);
				this.isMoving = false;
			}
		}
	}

	void open(){
		if (!this.isBlocked) {
			this.source.PlayOneShot (this.openingSound);
			targetRotY = this.closedRot.eulerAngles.y - 90;
			this.isOpen = true;
			this.isMoving = true;
			StartCoroutine (automaticClose ());
		} else {
			if (kc != null && kc.hasKey(neededKey)) {
				this.isBlocked = false;
				this.open ();
			} else {
				this.source.PlayOneShot (this.blockedSound);
			}
		}

	}

	public void close(){
		this.source.PlayOneShot (this.closingSound);
		targetRotY = this.closedRot.eulerAngles.y;
		this.isOpen = false;
		this.isMoving = true;
		StopAllCoroutines();
	}
}
