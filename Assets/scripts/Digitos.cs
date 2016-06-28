using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Digitos : MonoBehaviour {
    public int valor;
    public Texture[] text;
    
    // Use this for initialization
    void Start()
    {
        valor = 0;
    }

    public void changeNumber()
    {
        valor++;
        valor = valor % 10;
        GetComponent<Renderer>().material.mainTexture = text[valor];
    }
}
