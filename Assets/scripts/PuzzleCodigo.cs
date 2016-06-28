using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PuzzleCodigo : MonoBehaviour {

    public Cursor cursor;
    public Text mytext;
    public GameObject firstdigit;
    public GameObject seconddigit;
    public GameObject thirddigit;
    public GameObject centena;
    public GameObject decena;
    public GameObject unidad;
    public Texture[] text;
    private int code;
    private bool logrado;

    // Use this for initialization
    void Start()
    {
        code = Random.Range(0, 1000);
        //mytext.text = code.ToString();
        ponerCodigo();
        logrado = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!logrado)
        {
            GameObject obj = cursor.getPointedObject();
            if (obj != null && Input.GetMouseButtonDown(0))
            {
                string name = obj.transform.name;
                meSelecciono(name);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                reset();
            }
            seLogro();
        }

    }
    void ponerCodigo()
    {
        int a = code / 100;
        int b = code % 100;
        b = b / 10;
        int c = code % 10;
        centena.GetComponent<Renderer>().material.mainTexture = text[a];
        decena.GetComponent<Renderer>().material.mainTexture = text[b];
        unidad.GetComponent<Renderer>().material.mainTexture = text[c];
    }
    void meSelecciono(string name)
    {
        Digitos dig1 = firstdigit.GetComponent<Digitos>();
        Digitos dig2 = seconddigit.GetComponent<Digitos>();
        Digitos dig3 = thirddigit.GetComponent<Digitos>();
        switch (name)
        {
            case "Flecha1":
                //mytext.text = "Dig1";
                dig1.changeNumber();
                dig2.changeNumber();
                dig3.changeNumber();
                break;
            case "Flecha2":
                //mytext.text = "Dig2";
                dig2.changeNumber();
                dig3.changeNumber();
                break;
            case "Flecha3":
                //mytext.text = "Dig3";
                dig3.changeNumber();
                break;
        }
    }

    void seLogro()
    {
        Digitos pdig = firstdigit.GetComponent<Digitos>();
        Digitos sdig = seconddigit.GetComponent<Digitos>();
        Digitos tdig = thirddigit.GetComponent<Digitos>();
        int num = 0;
        int a = tdig.valor;
        int b = sdig.valor;
        int c = pdig.valor;
        num = (a * 100) + (b * 10) + c;
        if (num == code)
        {
            logrado = true;
            mytext.text = "Logrado!";
            Destroy(firstdigit);
            Destroy(seconddigit);
            Destroy(thirddigit);
            Destroy(centena);
            Destroy(decena);
            Destroy(unidad);
        }
    }
    void reset()
    {
        Digitos pdig = firstdigit.GetComponent<Digitos>();
        Digitos sdig = seconddigit.GetComponent<Digitos>();
        Digitos tdig = thirddigit.GetComponent<Digitos>();
        pdig.valor = -1;
        sdig.valor = -1;
        tdig.valor = -1;
        pdig.changeNumber();
        sdig.changeNumber();
        tdig.changeNumber();
    }
}
