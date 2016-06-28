using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class CupController : MonoBehaviour {

    public int times;
    //public int con;
    public GameObject obj;
    public Text mtext;
    public bool correctPos;
    public GameObject player;
    public int ang1;
    public int ang2;
    public int ang3;
    public int ang4;
	// Use this for initialization
	void Start () {
        //con =  0;
        correctPos = false;
        times = 0;
	}
	
	// Update is called once per frame
	void Update () {
        float distance = Vector3.Distance(transform.position, player.transform.position);
        if (Math.Abs(distance) <= 4 && Input.GetMouseButtonDown(0))
        {
            //305 - 35 - 125 - 215
            //125 - 215 - 305 - 35
            times = times % 4;
            if (times == 0)
            {
                transform.localEulerAngles = new Vector3(0, ang1, 0);
            }
            else if (times == 1)
            {
                transform.localEulerAngles = new Vector3(0, ang2, 0);
            }
            else if (times == 2)
            {
                transform.localEulerAngles = new Vector3(0, ang3, 0);
            }
            else if (times == 3)
            {
                transform.localEulerAngles = new Vector3(0, ang4, 0);
            }
            Ver();
            times++;
            //transform.Rotate(new Vector3(0,1,0), Space.World);
            
        }
	}

    void Ver()
    {
        //bool res = false;
        TextureChanger mytext = obj.GetComponent<TextureChanger>();
        int aux = mytext.number;
        switch (aux)
        {
            case 1:
                if (times == 0)
                {
                    //mtext.text = "well done2";
                    correctPos = true;
                }
                else
                {
                    correctPos = false; 
                    //mtext.text = ":/";
                }
                break;
            case 2:
                if (times == 1)
                {
                    //mtext.text = "well done3";
                    correctPos = true;
                }
                else
                {
                    correctPos = false;
                    //mtext.text = ":'(";
                }
                break;
            case 3:
                if (times == 2)
                {
                    //mtext.text = "well done4";
                    correctPos = true;
                }
                else
                {
                    correctPos = false;
                    //mtext.text = ":S";
                }
                break;
        }
    }
}














/*
1 - Make Health public.

public class PlayerScript: MonoBehaviour {
    public float Health = 100.0f;
}
2 - Access it.

public class Accessor : MonoBehaviour {
    void Start()
    {
        GameObject thePlayer = GameObject.Find("ThePlayer");
        PlayerScript playerScript = thePlayer.GetComponent<PlayerScript>();
        playerScript.Health -= 10.0f;
    }
}
*/