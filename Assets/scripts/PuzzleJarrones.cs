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
        if (!realizado)
        {
            realizado = seLogro();
            if (realizado)
            {
                mytext.text = "Lograste un puzzle!!! :D";
                Destroy(obj);
                Destroy(obj2);
            }
        }
	}

    private bool seLogro()
    {
        bool res = false;
        CupController jarron1 = obj.GetComponent<CupController>();
        CupController jarron2 = obj2.GetComponent<CupController>();
        bool res1 = jarron1.correctPos;
        bool res2 = jarron2.correctPos;
        res = res1 && res2;
        return res;
    }
}
