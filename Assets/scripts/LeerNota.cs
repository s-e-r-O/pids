using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LeerNota : MonoBehaviour {

	public Cursor cursor;
	public GameObject Hoja;

	private bool showMessage;
	GameObject mainCamera;

	// Use this for initialization
	void Start () {
		mainCamera = GameObject.FindWithTag ("MainCamera");
		Hoja.SetActive (false);
		this.showMessage = false;
	}

	// Update is called once per frame
	void Update () {

	}

	void OnTriggerStay(Collider objetoPlayer)
	{
		if (objetoPlayer.tag == "Player") 
		{
			GameObject obj = cursor.getPointedObject ();
			if (obj.CompareTag("Nota")) 
			{
				showMessage = true;

				if (Input.GetMouseButtonDown(0))//0=click izq, 1= click derecho, 2= rueda del mouse o .GetKeyDown("la letra que queramos")
				{
					Hoja.SetActive (true);
				}
				else if (Input.GetMouseButtonDown(1))
				{
					Hoja.SetActive(false);
				}
			}
		}
	}

	void OnTriggerExit(Collider objetoPlayer)
	{
		Hoja.SetActive(false);
	}

	void OnGUI()
	{
		if (showMessage) 
		{
			GUI.Label(new Rect (400,100,100,100), "CLick derecho para ver la nota y click izquierdo para salir");
			StartCoroutine (Visibility ());
		}
	}

	private IEnumerator Visibility()
	{
		yield return new WaitForSeconds (4);
		showMessage = false;
	}
}