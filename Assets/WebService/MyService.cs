using UnityEngine;
using System.Collections;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using System;

public class MyService {

    public string url = "http://127.0.0.1:8081/";

    /*DETALLES DE LOS PARAMETROS

    	PATH.-
    	Unicamente estas cadenas : 
    	lavatorioLevel
    	aguasLevel
    	catacombsLevel
    	vista360

		PUZZLENUMBER.-
		indica el numero del puzzle al que haces referencia
		Debe ser string como : 
		primerPuzzle
		segundoPuzzle
		tercerPuzzle
		OJO : en el caso de vista360 dejar los siguientes parametros vacios puzzlenumber = "" y newPuzzle = ""

    	NEWTRIGGER.-
    	SOLO DOS VALORES: true o false
    	Disparador que activa un evento como abrir una puerta

    	NEWPUZZLE.-
    	SOLO DOS VALORES:  true o false
    	Disparador que activa el puzzle indicado

    	VALOR.-
    	pasarle el valor que desean recibir
    	Unicamente : 
    	trigger
    	puzzle

    	PUZZLEINDEX.- 
    	Indica el numero del puzzle del cual deseas obtener los datos emepezando desde el 0
    	0 = puzzle1
    	1 = puzzle2
    	2 = puzzle3
    	...
    */

    public void updateData(string path , string puzzleNumber, string newTrigger , string newPuzzle)
	{
		url = "http://127.0.0.1:8081/"  + path + "/" + puzzleNumber + "/" + newTrigger + "/" + newPuzzle;

		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		request.Method = "PUT";

		HttpWebResponse response = (HttpWebResponse)request.GetResponse();

		using(var responseString = new StreamReader(response.GetResponseStream()))
		{
			responseString.ReadToEnd();
		}

	}
		
	public string getData(int puzzleindex , string valor, string path)
	{
		url = "http://127.0.0.1:8081/" + path;
		
		HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
		request.ContentType = "application/json";
		request.Method = "GET";

		HttpWebResponse response = (HttpWebResponse)request.GetResponse();
		using (var responseString = new StreamReader(response.GetResponseStream()))
		{
			string result;
			result = responseString.ReadToEnd();
			JArray myTrigger;
			try
			{
				myTrigger = JArray.Parse(result);
				switch (puzzleindex)
				{
				case 0 :
					return checkData(0,valor,myTrigger);
				case 1 :
					return checkData(1,valor,myTrigger);
				case 2 :
					return checkData(2,valor,myTrigger);
				case 3:
					return checkData(3,valor,myTrigger);
				case 4 :
					return checkData(4,valor,myTrigger);
				case 5: 
					return checkData(5,valor,myTrigger);
				case 6:
					return checkData(6,valor,myTrigger);
				default:
					return "Incorrect puzzle index";			
				}
			}
			catch(Exception)
			{
				return "null";
			}
		}
	}
		
	private string checkData(int index, string valor, JArray myTrigger)
	{
		if(valor == "trigger") {
			if (myTrigger[index]["trigger"].ToString() == "true") {
				return "true";
			}					
			else {
				return "false";
			}
		}	
		if(valor == "puzzle") {
			if(myTrigger[index]["puzzle"].ToString() == "true"){
				return "true";						
			}
			else {
				return "false";
			}
		}
		else {
			return "Parametro erroneo";
		}
	}

}