using UnityEngine;
using System.Collections;

public class TriggerLocker : MonoBehaviour {

	public Door[] doorsToLock;

	void OnTriggerEnter(){
		for (int i=0; i<doorsToLock.Length; i++){
			doorsToLock [i].close();
			doorsToLock [i].isBlocked = true;
			doorsToLock [i].neededKey = -1;
		}
		Destroy (this.gameObject);
	}
}
