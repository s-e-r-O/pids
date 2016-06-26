using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuzzleJarrones : MonoBehaviour {

    public GameObject obj;
    public GameObject obj2;
    public bool realizado;
    public Text mytext;

	// Use this for initialization
	void Start () {
        realizado = false;
	}
	
	// Update is called once per frame
	void Update () {
        bool aux = seLogro();
	    if (aux)
        {
            realizado = true;
        }
        if (realizado)
        {
            mytext.text = "Lograste un puzzle!!! :D";
        }
	}

    private bool seLogro()
    {
        bool res = false;
        CupController jarron1 = obj.GetComponent<CupController>();
        CupController2 jarron2 = obj2.GetComponent<CupController2>();
        bool res1 = jarron1.correctPos;
        bool res2 = jarron1.correctPos;
        res = res1 && res2;
        return res;
    }
}
