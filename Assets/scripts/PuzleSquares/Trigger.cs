using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour {

	public string message;
	public Light spotlight;
	public bool isExit;

	private bool insideTrigger;

	void Update (){
		if (!isExit) {
			if (insideTrigger) {
				turnOffLight ();
			} else {
				turnOnLight ();
			}
		}

	}

	private void turnOffLight(){
		if (spotlight.intensity > 0.1) {
			spotlight.intensity *= 0.6f;
		} else {
			spotlight.intensity = 0;
		}
	}

	private void turnOnLight(){
		if (spotlight.intensity < 6) {
			spotlight.intensity /= 0.6f;
		} else {
			spotlight.intensity = 6;
		}
	}

	// Use this for initialization
	void OnTriggerEnter(Collider player){
		if (player.CompareTag ("Player")) {
			if (!isExit) {
				insideTrigger = true;
			} else {
				Destroy (transform.parent.gameObject);
			}

		}
	}

	void OnTriggerExit(Collider player){
		if (player.CompareTag ("Player")) {
			insideTrigger = false;
			spotlight.intensity = 0.1f;
		}
	}

	void OnGUI(){
		if (insideTrigger) {
			GUI.Label(new Rect(0, 0,300,300), message);
		}
	}
}
