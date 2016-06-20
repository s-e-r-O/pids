using UnityEngine;
using System.Collections;

public class sceneChanger : MonoBehaviour {
	[SerializeField] private int sceneNum;
	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			LoadingScreenManager.LoadScene (sceneNum);
		}
	}

}
