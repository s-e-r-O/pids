using UnityEngine;
using System.Collections;

public class sceneChanger : MonoBehaviour {
	[SerializeField] private string sceneName;
	void OnTriggerEnter(Collider col){
		if (col.CompareTag ("Player")) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (sceneName);
		}
	}

}
