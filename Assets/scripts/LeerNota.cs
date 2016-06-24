using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeerNota : MonoBehaviour {

	public Cursor cursor;
	public GameObject Hoja;
	public Text texto;
	//public Light light;

	private bool showMessage;
	GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
		Hoja.SetActive (false); 
		texto.text = "";
		this.showMessage = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
		
	void OnTriggerStay(Collider objetoPlayer)
	{
		if (objetoPlayer.tag == "Player") 
		{
			//GameObject obj = cursor.getPointedObject ();
			//if (obj.CompareTag("Nota")) 
			//{
				showMessage = true;
				menssage ();
				if (Input.GetMouseButtonDown(0))//0=click izq, 1= click derecho, 2= rueda del mouse o .GetKeyDown("la letra que queramos")
				{
					Hoja.SetActive (true);
					//light.enabled;
				}
				else if (Input.GetMouseButtonDown(1))
				{
					Hoja.SetActive(false);
				}
			//}
		}
	}

	void menssage()
	{
		if (showMessage) 
		{
			texto.text = "click izq para ver la nota y click derecho para salir";
			StartCoroutine (Visibility ());
		}
	}
	void OnTriggerExit(Collider objetoPlayer)
	{
		Hoja.SetActive(false);
	}

	/*void OnGUI()
	{
		if (!aTexture) {
			Debug.LogError("Assign a Texture in the ir.");
			return;
		}
		GUI.DrawTexture (new Rect (1, 1, 6, 6), aTexture, ScaleMode.ScaleToFit, true, 10.0F);
	}*/

	private IEnumerator Visibility()
	{
		yield return new WaitForSeconds (3);
		showMessage = false;
	}
}