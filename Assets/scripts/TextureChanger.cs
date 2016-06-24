using UnityEngine;
using System.Collections;

public class TextureChanger : MonoBehaviour {

    public Texture text1;
    public Texture text2;
    public Texture text3;
    public Texture text4;
    public int number;

	void Start () {
        Texture text = random_Text();
        GetComponent<Renderer>().material.mainTexture = text;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    private Texture random_Text()
    {
        number = Random.Range(0, 4);
        Texture text = new Texture();
        switch (number)
        {
            case 0:
                text = text1;
                break;
            case 1:
                text = text2;
                break;
            case 2:
                text = text3;
                break;
            case 3:
                text = text4;
                break;
        }
        return text;
    }
}
