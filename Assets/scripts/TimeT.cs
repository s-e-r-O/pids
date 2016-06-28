using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;

public class TimeT : MonoBehaviour {

    public static TimeT timeC;
    public DateTime oldDate;
    public TimeSpan ts, difference;
    public Text mytext;

    void Start()
    {
        oldDate = DateTime.Now;
        Load();
    }

    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Save();
            Application.Quit();
        }

    }

    private void Calculate()
    {
        ts = DateTime.Now - oldDate;
        ts = ts.Add(difference);
    }
	
	public void Save ()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/timegame.dat");
        TimeP mytime = new TimeP();
        //mytime.time = DateTime.Now;
        Calculate();
        mytime.timePlayed = ts;
        bf.Serialize(file, mytime);
        file.Close();

        mytext.text = "You played: " + ts.Days + " days " + ts.Hours + " hours " + ts.Minutes + " minutes " + ts.Seconds + " seconds";
	}
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/timegame.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/timegame.dat", FileMode.Open);
            TimeP mytime = (TimeP)bf.Deserialize(file);
            file.Close();
            difference = mytime.timePlayed;
            
        }
        else
        {
            difference = TimeSpan.Zero;
        }
        //mytext.text = difference.ToString();
    }
}


[Serializable]
class TimeP
{
    //public DateTime time;
    public TimeSpan timePlayed;
}